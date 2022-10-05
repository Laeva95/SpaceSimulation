using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public ulong cp;
    public ulong dp;
    public ulong rp;
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

    private string SAVE_DATA_DIRECTORY;

    private string SAVE_FILENAME;

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

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("--Save--");
        Debug.Log(json);
    }
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
            Debug.Log("--Load--");
            Debug.Log(loadJson);
        }
        else
        {
            Debug.Log("저장된 파일이 없습니다.");
        }
    }
}
