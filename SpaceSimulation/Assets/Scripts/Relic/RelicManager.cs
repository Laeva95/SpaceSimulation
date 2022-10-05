using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class Relicinfo
{
    public string name;
    public string descript;
    public int cost;
}
public class RelicManager : MonoBehaviour
{
    public Relic[] m_Relics;
    public List<Relicinfo> m_Info = new List<Relicinfo>();
    public int[] m_RelicLevels;
    public int[] m_RelicEffects;

    [SerializeField]
    private GameObject[] m_RelicSets;
    [SerializeField]
    private GameObject m_RelicSet;


    private void Awake()
    {
        m_RelicLevels = new int[m_Relics.Length];
        m_RelicEffects = new int[] { 100, 100, 100, 100, 200, 200};
    }
    private void Start()
    {
        for (int i = 0; i < m_Relics.Length; i++)
        {
            m_Relics[i].m_Level = m_RelicLevels[i];
            m_Relics[i].m_Effect = m_RelicEffects[i];
            m_Relics[i].m_Number = i;
            m_Info.Add(LoadStage(i));
            UpdateText(m_Relics[i]);
        }

        for (int i = 0; i < m_Relics.Length; i++)
        {
            m_RelicSets[i].SetActive(false);
        }
        for (int i = 0; i < m_Relics.Length; i++)
        {
            if (m_Relics[i].m_Level > 0)
            {
                m_RelicSets[i].SetActive(true);
            }
        }
        FindObjectOfType<RelicInven>().ValidCheck();
        m_RelicSet.SetActive(false);
    }

    public void UpdateText(Relic _relic)
    {
        _relic.SetName(m_Info[_relic.m_Number].name);
        _relic.SetLevel(_relic.m_Level);
        _relic.SetDescript(m_Info[_relic.m_Number].descript);
        _relic.SetCost(m_Info[_relic.m_Number].cost);

        m_RelicLevels[_relic.m_Number] = _relic.m_Level;
    }
    public static Relicinfo LoadStage(int _number)
    {
        //1. 리소스 파일에서 텍스트를 읽어온다.
        TextAsset textAsset = Resources.Load<TextAsset>($"RelicItem/{GetFileName(_number)}");
        if (textAsset != null)
        {
            Relicinfo relicinfo = JsonUtility.FromJson<Relicinfo>(textAsset.text);

            return relicinfo;
        }

        return null;
    }

    // 'stage_000x'와 같은 형식의 이름을 갖는 string 타입 반환
    static string GetFileName(int _number)
    {
        return string.Format("RelicItem{0:D2}", _number);
    }
}
