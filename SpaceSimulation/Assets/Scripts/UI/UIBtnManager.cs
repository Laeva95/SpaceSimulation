using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBtnManager : MonoBehaviour
{
    public GameObject m_Space, m_Planet, m_SpaceUp, m_PlanetUp;
    public SpaceCreationManager m_SpaceCreationManager;
    [SerializeField]
    private Text m_SpacePlanetSwitchText;
    [SerializeField]
    private GameObject m_UpSet, m_RebirthSet, m_BattleSet, m_ShopSet;
    
    public void SpacePlanetSwitchBtn()
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
}
