using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationManager : MonoBehaviour
{
    [HideInInspector]
    public SpaceCreation[] m_SpaceCreations;
    [HideInInspector]
    public int[] m_Levels;
    [HideInInspector]
    public ulong m_TotalCreatePower;

    public PlayerResourceManager m_Resource;

    public GameObject[] m_SpaceCreationsObj;
    public GameObject m_BackGroundObj;

    WaitForSeconds m_Sec = new WaitForSeconds(1f);

    private void Awake()
    {
        m_SpaceCreations = new SpaceCreation[m_SpaceCreationsObj.Length];
        m_Levels = new int[m_SpaceCreationsObj.Length];
        for (int i = 0; i < m_SpaceCreations.Length; i++)
        {
            switch (i)
            {
                case 0:
                    m_SpaceCreations[i] = new SpaceCreationTier0(m_Levels[i], i);
                    break;
                case 1:
                    m_SpaceCreations[i] = new SpaceCreationTier1(m_Levels[i], i);
                    break;
                case 2:
                    m_SpaceCreations[i] = new SpaceCreationTier2(m_Levels[i], i);
                    break;
                case 3:
                    m_SpaceCreations[i] = new SpaceCreationTier3(m_Levels[i], i);
                    break;
                case 4:
                    m_SpaceCreations[i] = new SpaceCreationTier4(m_Levels[i], i);
                    break;
                case 5:
                    m_SpaceCreations[i] = new SpaceCreationTier5(m_Levels[i], i);
                    break;
                case 6:
                    m_SpaceCreations[i] = new SpaceCreationTier6(m_Levels[i], i);
                    break;
                case 7:
                    m_SpaceCreations[i] = new SpaceCreationTier7(m_Levels[i], i);
                    break;
                case 8:
                    m_SpaceCreations[i] = new SpaceCreationTier8(m_Levels[i], i);
                    break;
                default:
                    break;
            }
        }
        StartCoroutine(CreatePowerPerSec());
    }
    IEnumerator CreatePowerPerSec()
    {
        while (true)
        {
            m_Resource.CreatePower += m_TotalCreatePower;
            yield return m_Sec;
        }
    }

    public void StatusUpdate()
    {
        ulong count = 0;
        for (int i = 0; i < m_SpaceCreations.Length; i++)
        {
            m_SpaceCreations[i].StatusUpdate();
            count += m_SpaceCreations[i].m_CreatPower;
        }

        m_TotalCreatePower = count;

        m_Resource.Touch.SetTouchCreatePowerIncrease(m_TotalCreatePower);
    }
    public void LevelUp(SpaceCreation _creation)
    {
        if (m_BackGroundObj.activeSelf)
        {
            m_SpaceCreationsObj[_creation.m_Tier].SetActive(true);
        }

        _creation.m_Level++;
        StatusUpdate();
    }
    public void LevelUp(SpaceCreation _creation, int _level)
    {
        if (m_BackGroundObj.activeSelf)
        {
            m_SpaceCreationsObj[_creation.m_Tier].SetActive(true);
        }

        _creation.m_Level = _level;
        StatusUpdate();
    }
}
