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
    private GameObject m_ErrorText2;
    [SerializeField]
    private GameObject m_UpSet, m_RebirthSet, m_BattleSet, m_ShopSet;
    int count = 1;

    [SerializeField]
    private Button m_Rebirth0, m_Rebirth1;

    private void Start()
    {
        SetSpaceUpText();
        SetPlanetUpText();
        m_Resource.UpdateText();
        CheckPlanetActive();
    }
    #region 메인 버튼 Set
    public void SpacePlanetSwitchBtn()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[4].m_Level > 0)
        {
            if (m_Space.activeSelf)
            {
                Switch(m_Space.activeSelf);
            }
            else
            {
                Switch(m_Space.activeSelf);
            }
        }
        else
        {
            m_ErrorText0.SetActive(true);
        }
    }
    void Switch(bool _bool)
    {
        if (_bool)
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
                else
                {
                    m_PlanetCreationManager.m_PlanetCreationsObj[i].SetActive(false);
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
                else
                {
                    m_SpaceCreationManager.m_SpaceCreationsObj[i].SetActive(false);
                }
            }
            for (int i = 0; i < m_PlanetCreationManager.m_PlanetCreationsObj.Length; i++)
            {
                m_PlanetCreationManager.m_PlanetCreationsObj[i].SetActive(false);
            }
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
        SaveManager.Instance.SaveData();
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
            if (m_SpaceCreationManager.m_SpaceCreations[0].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_SpaceCreationManager.m_SpaceCreations[1].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_SpaceCreationManager.m_SpaceCreations[2].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_SpaceCreationManager.m_SpaceCreations[3].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[4].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[4]);
            SetSpaceUpText();
            CheckPlanetActive();
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
            if (m_SpaceCreationManager.m_SpaceCreations[4].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_SpaceCreationManager.m_SpaceCreations[5].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_SpaceCreationManager.m_SpaceCreations[6].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_SpaceCreationManager.m_SpaceCreations[7].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
            m_Resource.CreatePower -= m_SpaceCreationManager.m_SpaceCreations[8].m_NextLevelCost;
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[8]);
            SetSpaceUpText();
        }
        else
        {
            m_ErrorText1.SetActive(true);
        }
    }

    private void CheckPlanetActive()
    {

        if (m_SpaceCreationManager.m_SpaceCreations[4].m_Level > 0)
        {
            m_Rebirth1.interactable = true;
        }
        else
        {
            m_Rebirth1.interactable = false;
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
        SaveManager.Instance.SaveData();
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
            if (m_PlanetCreationManager.m_PlanetCreations[0].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_PlanetCreationManager.m_PlanetCreations[1].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_PlanetCreationManager.m_PlanetCreations[2].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_PlanetCreationManager.m_PlanetCreations[3].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
            if (m_PlanetCreationManager.m_PlanetCreations[4].m_Level == 0)
            {
                m_ErrorText2.SetActive(true);
                return;
            }
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
        for (int i = 0; i < m_PlanetCreationManager.m_PlanetCreations.Length; i++)
        {
            if (m_PlanetCreationManager.m_PlanetCreations[i] != null)
            {
                if (m_PlanetCreationManager.m_PlanetCreations[i].m_Level > 0)
                {
                    count = 1 + m_PlanetCreationManager.m_PlanetCreations[i].m_Tier;
                }
            }
        }

        m_RebirthText.text =
            $"You can rebirth if your planet is level 1 or higher. All Space and Planet upgrades are reset, but you can get {(ulong)(Mathf.Pow((Mathf.Pow(m_Resource.TotalCP, 0.2f)), 1 + (count * 0.4f)))} RP.";
    }
    public void RebirthBtn()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[4].m_Level > 0)
        {
            GetRevirthReward(false);
            RevirthInit();
            RebirthTextUpdate();
            SaveManager.Instance.SaveData();
        }
        else
        {
            m_ErrorText0.SetActive(true);
        }
    }
    public void RebirthADBtn()
    {
        if (m_SpaceCreationManager.m_SpaceCreations[4].m_Level > 0)
        {
            GetRevirthReward(true);
            RevirthInit();
            RebirthTextUpdate();
            SaveManager.Instance.SaveData();
        }
        else
        {
            m_ErrorText0.SetActive(true);
        }
    }
    void RevirthInit()
    {
        m_Resource.CreatePower = 0;
        m_Resource.DivinityPower = 0;

        for (int i = 0; i < m_SpaceCreationManager.m_SpaceCreations.Length; i++)
        {
            m_SpaceCreationManager.LevelUp(m_SpaceCreationManager.m_SpaceCreations[i], 0);
        }

        for (int i = 0; i < m_PlanetCreationManager.m_PlanetCreations.Length; i++)
        {
            m_PlanetCreationManager.LevelUp(m_PlanetCreationManager.m_PlanetCreations[i], 0);
        }

        Switch(false);
        SetPlanetUpText();
        SetSpaceUpText();
        CheckPlanetActive();

    }
    void GetRevirthReward(bool _isRewardedAD)
    {
        ulong reward = 0;
        reward = _isRewardedAD ? (ulong)(Mathf.Pow((Mathf.Pow(m_Resource.TotalCP, 0.2f)), 1 + (count * 0.4f))) * 2 : (ulong)(Mathf.Pow((Mathf.Pow(m_Resource.TotalCP, 0.2f)), 1 + (count * 0.4f)));
        Debug.Log(reward);

        m_Resource.RebirthPoint += reward;
        m_Resource.TotalCP = 0;
    }
    #endregion
}
