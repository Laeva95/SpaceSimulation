using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgrade : MonoBehaviour
{
    [SerializeField]
    Text m_CPAD, m_CPADCost, m_DPAD, m_DPADCost;
    [SerializeField]
    Text[] m_CostText, m_LevelText, m_DescriptText;
    [SerializeField]
    RelicManager m_Relic;
    [SerializeField]
    PlayerResourceManager m_Resource;
    [SerializeField]
    SpaceCreationManager m_Space;
    [SerializeField]
    PlanetCreationManager m_Planet;


    public int[] m_ShopLevel;
    public int[] m_ShopEffects;

    private void Awake()
    {
        m_ShopLevel = new int[m_CostText.Length];
        m_ShopEffects = new int[] { 100, 100, 100, 100 };
    }
    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        m_CPAD.text = $"Watch ads and get " +
            $"{Utils.Caculation(m_Space.m_TotalCreatePower * (ulong)(1 + m_Relic.m_Relics[0].m_Level + (m_Relic.m_Relics[4].m_Level * 2)) * 1800)} CP as a reward";
        m_DPAD.text = $"Watch ads and get " +
            $"{Utils.Caculation(m_Planet.m_TotalDivinityPower * (ulong)(1 + m_Relic.m_Relics[1].m_Level + (m_Relic.m_Relics[5].m_Level * 2)) * 1800)} DP as a reward";
        for (int i = 0; i < m_ShopLevel.Length; i++)
        {
            m_CostText[i].text = $"{ Utils.Caculation((ulong)(1 + m_ShopLevel[i]) * 10)} RP";
            m_LevelText[i].text = $"{m_ShopLevel[i]} Lv";
            m_DescriptText[i].text = string.Format(DecriptText(i), m_ShopLevel[i] * m_ShopEffects[i]);
        }
    }
    string DecriptText(int num)
    {
        string str = "";
        switch (num)
        {
            case 0:
                str = "CP per Sec + {0}%";
                break;
            case 1:
                str = "DP per Sec + {0}%";
                break;
            case 2:
                str = "CP per Click + {0}%";
                break;
            case 3:
                str = "DP per Click + {0}%";
                break;
        }
        return str;
    }

    public void CPAD()
    {

    }
    public void DPAD()
    {

    }
    public void UpgradeBtn0()
    {
        if (m_Resource.RebirthPoint > (ulong)((1 + m_ShopLevel[0]) * 10))
        {
            m_Resource.RebirthPoint -= (ulong)((1 + m_ShopLevel[0]) * 10);
            ShopUpgradeBtn(0);
        }
    }
    public void UpgradeBtn1()
    {
        if (m_Resource.RebirthPoint > (ulong)((1 + m_ShopLevel[1]) * 10))
        {
            m_Resource.RebirthPoint -= (ulong)((1 + m_ShopLevel[1]) * 10);
            ShopUpgradeBtn(1);
        }
    }
    public void UpgradeBtn2()
    {
        if (m_Resource.RebirthPoint > (ulong)((1 + m_ShopLevel[2]) * 10))
        {
            m_Resource.RebirthPoint -= (ulong)((1 + m_ShopLevel[2]) * 10);
            ShopUpgradeBtn(2);
        }
    }
    public void UpgradeBtn3()
    {
        if (m_Resource.RebirthPoint > (ulong)((1 + m_ShopLevel[3]) * 10))
        {
            m_Resource.RebirthPoint -= (ulong)((1 + m_ShopLevel[3]) * 10);
            ShopUpgradeBtn(3);
        }
    }
    void ShopUpgradeBtn(int num)
    {
        m_ShopLevel[num] = m_ShopLevel[num] + 1;
        UpdateText();
        m_Resource.UpdateText();
    }
}
