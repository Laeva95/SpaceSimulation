using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

[System.Serializable]
public class SaveData
{
    public ulong cp;
    public ulong dp;
    public ulong rp;
    public string dataTime;
    public List<int> SCLevels = new List<int>();
    public List<int> PCLevels = new List<int>();
    public List<int> RelicLevels = new List<int>();
}
public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public static SaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    [SerializeField]
    PlayerResourceManager m_Resource;
    [SerializeField]
    SpaceCreationManager m_Space;
    [SerializeField]
    PlanetCreationManager m_Planet;
    [SerializeField]
    RelicManager m_Relic;

    [SerializeField]
    Text m_OfflineRewardText;
    [SerializeField]
    GameObject m_OfflineRewardSet;

    private string SAVE_DATA_DIRECTORY;

    private string SAVE_FILENAME;

    public long m_LastDateTime;

    private void Awake()
    {
        if (instance == null)
        {
            // instance가 비어있을 경우 해당 객체를 넣어줌
            instance = this;
        }

        SAVE_DATA_DIRECTORY = Application.persistentDataPath + "/Saves/";
        SAVE_FILENAME = "/SaveFile.txt";
        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
        }
    }
    private void Start()
    {
        LoadData();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(GameQuit());
        }
    }
    IEnumerator GameQuit()
    {
        yield return SaveDataCoroutine();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    IEnumerator SaveDataCoroutine()
    {
        SaveData();
        yield return new WaitForSeconds(0.5f);
    }
    #region 저장
    public void SaveData()
    {
        SaveData saveData = new SaveData();

        saveData.cp = m_Resource.CreatePower;
        saveData.dp = m_Resource.DivinityPower;
        saveData.rp = m_Resource.RebirthPoint;
        for (int i = 0; i < m_Space.m_SpaceCreations.Length; i++)
        {
            saveData.SCLevels.Add(m_Space.m_SpaceCreations[i].m_Level);
        }
        for (int i = 0; i < m_Planet.m_PlanetCreations.Length; i++)
        {
            saveData.PCLevels.Add(m_Planet.m_PlanetCreations[i].m_Level);
        }
        for (int i = 0; i < m_Relic.m_RelicLevels.Length; i++)
        {
            saveData.RelicLevels.Add(m_Relic.m_RelicLevels[i]);
        }
        saveData.dataTime = SetLastPlayDate();

        string json = JsonUtility.ToJson(saveData);

        SetLastPlayDate();

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);
    }
    #endregion
    #region 불러오기
    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // 저장된 json 파일을 불러옴
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);

            // json 형식의 데이터를 SaveData의 형식으로 저장함
            SaveData loadData = JsonUtility.FromJson<SaveData>(loadJson);

            m_Resource.CreatePower = loadData.cp;
            m_Resource.DivinityPower = loadData.dp;
            m_Resource.RebirthPoint = loadData.rp;
            for (int i = 0; i < m_Space.m_SpaceCreations.Length; i++)
            {
                if (loadData.SCLevels[i] != 0)
                {
                    m_Space.m_Levels[i] = loadData.SCLevels[i];
                }
            }
            for (int i = 0; i < m_Planet.m_PlanetCreations.Length; i++)
            {
                if (loadData.PCLevels[i] != 0)
                {
                    m_Planet.m_Levels[i] = loadData.PCLevels[i];
                }
            }
            for (int i = 0; i < m_Relic.m_RelicLevels.Length; i++)
            {
                m_Relic.m_RelicLevels[i] = loadData.RelicLevels[i];
            }

            m_Resource.UpdateText();

            m_LastDateTime = (int)DateTime.Now.Subtract(GetLastPlayDate(loadData.dataTime)).TotalSeconds;
            Debug.Log(m_LastDateTime);
            if (m_LastDateTime > 86400)
            {
                m_LastDateTime = 86400;
            }

            if (m_LastDateTime > 0)
            {
                StartCoroutine(TimeAfterLoadData());
            }

            Debug.Log("--Load--");
            Debug.Log(loadJson);
        }
        else
        {
            Debug.Log("저장된 파일이 없습니다.");
        }
    }
    #endregion
    IEnumerator TimeAfterLoadData()
    {
        yield return new WaitForSeconds(1f);
        m_OfflineRewardSet.SetActive(true);
        m_Resource.CreatePower += (ulong)m_LastDateTime * CPCal();
        m_Resource.DivinityPower += (ulong)m_LastDateTime * DPCal();

        m_OfflineRewardText.text = 
            $"Gained {Utils.Caculation(CPCal() * (ulong)m_LastDateTime)} CP and {Utils.Caculation(DPCal() * (ulong)m_LastDateTime)} DP while {TimeCal()}.";
    }
    #region CP, DP 연산
    ulong CPCal()
    {
        return m_Space.m_TotalCreatePower
            * (ulong)(1 + m_Relic.m_Relics[0].m_Level + (m_Relic.m_Relics[4].m_Level * 2));
    }
    ulong DPCal()
    {
        return m_Planet.m_TotalDivinityPower
            * (ulong)(1 + m_Relic.m_Relics[1].m_Level + (m_Relic.m_Relics[5].m_Level * 2));
    }
    string TimeCal()
    {
        string time = (m_LastDateTime / 3600).ToString() + "h" 
            + ((m_LastDateTime % 3600) / 60).ToString() + "m" 
            + ((m_LastDateTime % 3600) % 60).ToString() + "s";
        return time;
    }
    public void OfflineSetFalse()
    {
        m_OfflineRewardSet.SetActive(false);
    }
    #endregion
    string SetLastPlayDate()
    {
        return DateTime.Now.ToBinary().ToString();
    }

    DateTime GetLastPlayDate(string _dateTime)
    {
        if (_dateTime == null)
            return DateTime.Now;

        string binaryLastPlayDate = _dateTime;
        long longLastPlayDate = Convert.ToInt64(binaryLastPlayDate);

        Debug.Log(DateTime.FromBinary(longLastPlayDate));
        Debug.Log(DateTime.Now);

        return DateTime.FromBinary(longLastPlayDate);
    }
}
