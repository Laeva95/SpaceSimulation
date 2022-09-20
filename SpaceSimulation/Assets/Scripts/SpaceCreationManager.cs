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
    public int m_TotalCreatePower;

    public PlayerResourceManager m_Resource;

    public GameObject[] m_SpaceCreationsObj;

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
                    m_SpaceCreations[i] = new SpaceCreationTier0(m_Levels[i]);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
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
            Debug.Log($"CreatePower: {m_Resource.CreatePower}");
            Debug.Log($"DivinityPower: {m_Resource.DivinityPower}");
            yield return m_Sec;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp(m_SpaceCreations[0]);
        }
    }
    public void StatusUpdate()
    {
        int count = 0;
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
        m_SpaceCreationsObj[_creation.m_Tier].SetActive(true);

        _creation.m_Level++;
        StatusUpdate();
    }
    public void LevelUp(SpaceCreation _creation, int _level)
    {
         m_SpaceCreationsObj[_creation.m_Tier].SetActive(true);

        _creation.m_Level = _level;
        StatusUpdate();
    }
}
