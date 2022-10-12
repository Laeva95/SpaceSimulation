using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationManager : MonoBehaviour
{
    [HideInInspector]
    public PlanetCreation[] m_PlanetCreations;
    [HideInInspector]
    public int[] m_Levels;
    [HideInInspector]
    public ulong m_TotalDivinityPower;

    [SerializeField]
    PlayerResourceManager m_Resource;
    [SerializeField]
    RelicManager m_Relic;
    [SerializeField]
    ShopUpgrade m_Shop;

    public GameObject[] m_PlanetCreationsObj;
    public GameObject m_BackGroundObj;

    WaitForSeconds m_Sec = new WaitForSeconds(1f);

    private void Awake()
    {
        m_PlanetCreations = new PlanetCreation[m_PlanetCreationsObj.Length];
        m_Levels = new int[m_PlanetCreationsObj.Length];
    }
    private void Start()
    {
        for (int i = 0; i < m_PlanetCreations.Length; i++)
        {
            switch (i)
            {
                case 0:
                    m_PlanetCreations[i] = new PlanetCreationTier0(m_Levels[i], i);
                    break;
                case 1:
                    m_PlanetCreations[i] = new PlanetCreationTier1(m_Levels[i], i);
                    break;
                case 2:
                    m_PlanetCreations[i] = new PlanetCreationTier2(m_Levels[i], i);
                    break;
                case 3:
                    m_PlanetCreations[i] = new PlanetCreationTier3(m_Levels[i], i);
                    break;
                case 4:
                    m_PlanetCreations[i] = new PlanetCreationTier4(m_Levels[i], i);
                    break;
                case 5:
                    m_PlanetCreations[i] = new PlanetCreationTier5(m_Levels[i], i);
                    break;
                default:
                    break;
            }
        }
        StatusUpdate();
        StartCoroutine(DiviniryPowerPerSec());
    }
    IEnumerator DiviniryPowerPerSec()
    {
        while (true)
        {
            m_Resource.DivinityPower += m_TotalDivinityPower 
                * (ulong)(1 + m_Relic.m_Relics[1].m_Level + (m_Relic.m_Relics[5].m_Level * 2))
                * (ulong)(1 + m_Shop.m_ShopLevel[1]);
            m_Resource.UpdateText();
            yield return m_Sec;
        }
    }

    public void StatusUpdate()
    {
        ulong count = 0;
        for (int i = 0; i < m_PlanetCreations.Length; i++)
        {
            m_PlanetCreations[i].StatusUpdate();
            count += m_PlanetCreations[i].m_DivinityPower;
        }

        m_TotalDivinityPower = count;

        m_Resource.Touch.SetTouchDivinityPowerIncrease(m_TotalDivinityPower 
            * (ulong)(1 + m_Relic.m_Relics[3].m_Level)
            * (ulong)(1 + m_Shop.m_ShopLevel[3]));
    }
    public void LevelUp(PlanetCreation _creation)
    {
        if (m_BackGroundObj.activeSelf)
        {
            m_PlanetCreationsObj[_creation.m_Tier].SetActive(true);
        }

        _creation.m_Level++;
        StatusUpdate();
    }
    public void LevelUp(PlanetCreation _creation, int _level)
    {
        if (m_BackGroundObj.activeSelf)
        {
            if (_level > 0)
            {
                m_PlanetCreationsObj[_creation.m_Tier].SetActive(true);
            }
        }

        _creation.m_Level = _level;
        StatusUpdate();
    }
}
