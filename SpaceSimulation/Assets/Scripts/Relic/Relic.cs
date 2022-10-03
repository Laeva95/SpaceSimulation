using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relic : MonoBehaviour
{
    private Text[] m_Texts;
    public int m_Level;
    private void Awake()
    {
        m_Texts = GetComponentsInChildren<Text>();
    }

    #region 유물 텍스트 설정
    public void SetName(string _name)
    {
        m_Texts[0].text = _name;
    }
    public void SetLevel(int _level)
    {
        m_Texts[1].text = _level.ToString();
        m_Level = _level;
    }
    public void SetDescript(string _descript)
    {
        m_Texts[2].text = _descript;
    }
    public void SetCost(string _cost)
    {
        m_Texts[3].text = _cost;
    }
    #endregion

    public void LevelUpBtn()
    { 

    }
}
