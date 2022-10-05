using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relic : MonoBehaviour
{
    private PlayerResourceManager m_Resource;
    private RelicInven m_Inven;
    private Text[] m_Texts;
    public int m_Level;
    public int m_Cost;
    public int m_Number;
    public int m_Effect;
    private void Awake()
    {
        m_Texts = GetComponentsInChildren<Text>();
        m_Resource = FindObjectOfType<PlayerResourceManager>();
        m_Inven = FindObjectOfType<RelicInven>();
    }

    #region 유물 텍스트 설정
    public void SetName(string _name)
    {
        m_Texts[0].text = _name;
    }
    public void SetLevel(int _level)
    {
        m_Texts[1].text = _level.ToString() + " Lv";
        m_Level = _level;
    }
    public void SetDescript(string _descript)
    {
        m_Texts[2].text = string.Format(_descript, m_Level * m_Effect);
    }
    public void SetCost(int _cost)
    {
        m_Cost = _cost * m_Level;
        m_Texts[3].text = m_Cost.ToString() + " RP";
    }
    #endregion

    public void LevelUpBtn()
    {
        if (m_Resource.RebirthPoint >= (ulong)m_Cost)
        {
            m_Resource.RebirthPoint -= (ulong)m_Cost;
            m_Inven.RelicLevenUp(this);
            SaveManager.Instance.SaveData();
        }
    }
}
