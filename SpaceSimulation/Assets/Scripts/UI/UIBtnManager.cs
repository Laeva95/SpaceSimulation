using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBtnManager : MonoBehaviour
{
    public GameObject m_Space, m_Planet, m_SpaceUp, m_PlanetUp;
    public SpaceCreationManager m_SpaceCreationManager;
    public PlanetCreationManager m_PlanetCreationManager;
    public PlayerResourceManager m_Resource;
    [SerializeField]
    private Text m_SpacePlanetSwitchText;
    [SerializeField]
    private GameObject m_ErrorText0;
    [SerializeField]
    private GameObject m_ErrorText1;
    [SerializeField]
    private GameObject m_UpSet, m_RebirthSet, m_BattleSet, m_ShopSet;

    private void Start()
    {
        SetSpaceUpText();
        SetPlanetUpText();
        m_Resource.UpdateText();
        RebirthTextUpdate();
    }
    #region 메인 버튼 Set
    public void SpacePlanetSwitchBtn()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[4].m_Level > 0)
        {
            if (m_Space.activeSelf)
            {
                m_Space.SetActive(false);
                m_SpaceUp.SetActive(false);
                m_Planet.SetActive(true);
                m_PlanetUp.SetActive(true);
                m_SpacePlanetSwitchText.text = "Planet";

                for (int i = 0; i < m_SpaceCreationManager.m_SpaceCreationsObj.Length; i++)
                {
                    m_SpaceCreationManager.m_SpaceCreationsObj[i].SetActive(false);
                }
                for (int i = 0; i < m_PlanetCreationManager.m_PlanetCreationsObj.Length; i++)
                {
                    if (m_PlanetCreationManager.m_PlanetCreations[i].m_Level > 0)
                    {
                        m_PlanetCreationManager.m_PlanetCreationsObj[i].SetActive(true);
                    }
                }
            }
            else
            {
                m_Space.SetActive(true);
                m_SpaceUp.SetActive(true);
                m_Planet.SetActive(false);
                m_PlanetUp.SetActive(false);
                m_SpacePlanetSwitchText.text = "Space";

                for (int i = 0; i < m_SpaceCreationManager.m_SpaceCreationsObj.Length; i++)
                {
                    if (m_SpaceCreationManager.m_SpaceCreations[i].m_Level > 0)
                    {
                        m_SpaceCreationManager.m_SpaceCreationsObj[i].SetActive(true);
                    }
                }
                for (int i = 0; i < m_PlanetCreationManager.m_PlanetCreationsObj.Length; i++)
                {
                    m_PlanetCreationManager.m_PlanetCreationsObj[i].SetActive(false);
                }
            }
        }
        else
        {
            m_ErrorText0.SetActive(true);
        }
    }
    public void UpgradeSetBtn()
    {
        m_UpSet.SetActive(true);
        m_RebirthSet.SetActive(false);
        m_BattleSet.SetActive(false);
        m_ShopSet.SetActive(false);
    }
    public void RebirthSetBtn()
    {
        m_UpSet.SetActive(false);
        m_RebirthSet.SetActive(true);
        m_BattleSet.SetActive(false);
        m_ShopSet.SetActive(false);
    }
    public void BattleSetBtn()
    {
        m_UpSet.SetActive(false);
        m_RebirthSet.SetActive(false);
        m_BattleSet.SetActive(true);
        m_ShopSet.SetActive(false);
    }
    public void ShopSetBtn()
    {
        m_UpSet.SetActive(false);
        m_RebirthSet.SetActive(false);
        m_BattleSet.SetActive(false);
        m_ShopSet.SetActive(true);
    }
    #endregion
    #region Space 업그레이드 Set
    [SerializeField]
    private Text[] m_SpaceCPText;
    [SerializeField]
    private Text[] m_SpaceLevelText;
    [SerializeField]
    private Text[] m_SpaceCostText;

    public void SetSpaceUpText()
    {
        for (int i = 0; i < m_SpaceCreationManager.m_SpaceCreations.Length; i++)
        {
            m_SpaceCPText[i].text = Utils.Caculation(m_SpaceCreationManager.m_SpaceCreations[i].m_CreatPower) + " CP/s";
            m_SpaceLevelText[i].text = m_SpaceCreationManager.m_SpaceCreations[i].m_Level.ToString() + " Lv";
            m_SpaceCostText[i].text = Utils.Caculation(m_SpaceCreationManager.m_SpaceCreations[i].m_NextLevelCost) + " CP";
        }
        m_Resource.UpdateText();
    }
    public void SpaceUpBtn0()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[0].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[0].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[0]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn1()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[1].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[1].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[1]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn2()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[2].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[2].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[2]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn3()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[3].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[3].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[3]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn4()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[4].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[4].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[4]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn5()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[5].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[5].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[5]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn6()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[6].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[6].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[6]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn7()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[7].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[7].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[7]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void SpaceUpBtn8()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[8].m_NextLevelCost <= m_Resource.CreatePower)
        {
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[8].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[8]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }

    #endregion
    #region Planet 업그레이드 Set
    [SerializeField]
    private Text[] m_PlanetDPText;
    [SerializeField]
    private Text[] m_PlanetLevelText;
    [SerializeField]
    private Text[] m_PlanetCostText;

    public void SetPlanetUpText()
    {
        for (int i = 0; i < m_PlanetCreationManager.m_PlanetCreations.Length; i++)
        {
            m_PlanetDPText[i].text = Utils.Caculation(m_PlanetCreationManager.m_PlanetCreations[i].m_DivinityPower) + " DP/s";
            m_PlanetLevelText[i].text = m_PlanetCreationManager.m_PlanetCreations[i].m_Level.ToString() + " Lv";
            m_PlanetCostText[i].text = Utils.Caculation(m_PlanetCreationManager.m_PlanetCreations[i].m_NextLevelCost) + " DP";
        }
        m_Resource.UpdateText();
    }
    public void PlanetUpBtn0()
    {
        if (m_PlanetCreationManager.m_PlanetCreations[0].m_NextLevelCost <= m_Resource.DivinityPower)
        {
            m_Resource.DivinityPower -= m_PlanetCreationManager.m_PlanetCreations[0].m_NextLevelCost;
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[0]);
            SetPlanetUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void PlanetUpBtn1()
    {
        if (m_PlanetCreationManager.m_PlanetCreations[1].m_NextLevelCost <= m_Resource.DivinityPower)
        {
            m_Resource.DivinityPower -= m_PlanetCreationManager.m_PlanetCreations[1].m_NextLevelCost;
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[1]);
            SetPlanetUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void PlanetUpBtn2()
    {
        if (m_PlanetCreationManager.m_PlanetCreations[2].m_NextLevelCost <= m_Resource.DivinityPower)
        {
            m_Resource.DivinityPower -= m_PlanetCreationManager.m_PlanetCreations[2].m_NextLevelCost;
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[2]);
            SetPlanetUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void PlanetUpBtn3()
    {
        if (m_PlanetCreationManager.m_PlanetCreations[3].m_NextLevelCost <= m_Resource.DivinityPower)
        {
            m_Resource.DivinityPower -= m_PlanetCreationManager.m_PlanetCreations[3].m_NextLevelCost;
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[3]);
            SetPlanetUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void PlanetUpBtn4()
    {
        if (m_PlanetCreationManager.m_PlanetCreations[4].m_NextLevelCost <= m_Resource.DivinityPower)
        {
            m_Resource.DivinityPower -= m_PlanetCreationManager.m_PlanetCreations[4].m_NextLevelCost;
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[4]);
            SetPlanetUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }
    public void PlanetUpBtn5()
    {
        if (m_PlanetCreationManager.m_PlanetCreations[5].m_NextLevelCost <= m_Resource.DivinityPower)
        {
            m_Resource.DivinityPower -= m_PlanetCreationManager.m_PlanetCreations[5].m_NextLevelCost;
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[5]);
            SetPlanetUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }

    #endregion
    #region 환생 Set
    [SerializeField] Text m_RebirthText;
    public void RebirthTextUpdate()
    {
        m_RebirthText.text = "";
    }
    public void RebirthBtn()
    {

    }
    public void RebirthADBtn()
    {

    }
    #endregion
}
