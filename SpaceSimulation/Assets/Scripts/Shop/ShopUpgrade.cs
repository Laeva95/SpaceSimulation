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
    Button m_CPADBtn, m_DPADBtn;
    [SerializeField]
    RelicManager m_Relic;
    [SerializeField]
    PlayerResourceManager m_Resource;
    [SerializeField]
    SpaceCreationManager m_Space;
    [SerializeField]
    PlanetCreationManager m_Planet;

    public int m_CPADTimer;
    public int m_DPADTimer;
    public bool m_IsCPAD = true;
    public bool m_IsDPAD = true;
    public int[] m_ShopLevel;
    public int[] m_ShopEffects;
    WaitForSeconds Sec = new WaitForSeconds(1f);

    private void Awake()
    {
        m_ShopLevel = new int[m_CostText.Length];
        m_ShopEffects = new int[] { 100, 100, 100, 100 };
    }
    private void Start()
    {
        UpdateText();
        StartCoroutine(ADTimer());
    }
    IEnumerator ADTimer()
    {
        while (true)
        {
            if (m_CPADTimer > 0)
            {
                m_IsCPAD = false;
                m_CPADTimer--;
                m_CPADCost.text = m_CPADTimer.ToString() + " Sec";
                m_CPADBtn.interactable = false;
            }
            else
            {
                m_IsCPAD = true;
                m_CPADCost.text = "Rewarded AD";
                m_CPADBtn.interactable = true;
            }
            if (m_DPADTimer > 0)
            {
                m_IsDPAD = false;
                m_DPADTimer--;
                m_DPADCost.text = m_DPADTimer.ToString() + " Sec";
                m_DPADBtn.interactable = false;
            }
            else
            {
                m_IsDPAD = true;
                m_DPADCost.text = "Rewarded AD";
                m_DPADBtn.interactable = true;
            }
            yield return Sec;
        }
    }
    public void UpdateText()
    {
        m_CPAD.text = $"Watch ads and get " +
            $"{Utils.Caculation(m_Space.m_TotalCreatePower * (ulong)(1 + m_Relic.m_Relics[0].m_Level + (m_Relic.m_Relics[4].m_Level * 2)) * (ulong)(1 + m_ShopLevel[0]) * 1800)} CP as a reward";
        m_DPAD.text = $"Watch ads and get " +
            $"{Utils.Caculation(m_Planet.m_TotalDivinityPower * (ulong)(1 + m_Relic.m_Relics[1].m_Level + (m_Relic.m_Relics[5].m_Level * 2)) * (ulong)(1 + m_ShopLevel[1]) * 1800)} DP as a reward";
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
        if (m_CPADTimer > 0)
        {
            return;
        }
        m_Resource.CreatePower += 
            m_Space.m_TotalCreatePower 
            * (ulong)(1 + m_Relic.m_Relics[0].m_Level + (m_Relic.m_Relics[4].m_Level * 2)) 
            * (ulong)(1 + m_ShopLevel[0]) * 1800;
        m_Resource.TotalCP +=
            m_Space.m_TotalCreatePower
            * (ulong)(1 + m_Relic.m_Relics[0].m_Level + (m_Relic.m_Relics[4].m_Level * 2))
            * (ulong)(1 + m_ShopLevel[0]) * 1800;
        m_CPADTimer += 600;
    }
    public void DPAD()
    {
        if (m_DPADTimer > 0)
        {
            return;
        }
        m_Resource.DivinityPower +=
            m_Planet.m_TotalDivinityPower 
            * (ulong)(1 + m_Relic.m_Relics[1].m_Level + (m_Relic.m_Relics[5].m_Level * 2)) 
            * (ulong)(1 + m_ShopLevel[1]) * 1800;
        m_DPADTimer += 600;
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
