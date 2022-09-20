using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationManager : MonoBehaviour
{
    [HideInInspector]
    public SpaceCreation[] m_SpaceCreations;
    [HideInInspector]
    public int[] m_Levels;

    public GameObject[] m_SpaceCreationsObj;

    private void Awake()
    {
        m_SpaceCreations = new SpaceCreation[1];
        m_Levels = new int[1];
        for (int i = 0; i < m_SpaceCreations.Length; i++)
        {
            switch (i)
            {
                case 0:
                    m_SpaceCreations[i] = new SpaceCreationTier0(m_Levels[i]);
                    break;
                default:
                    break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp(m_SpaceCreations[0]);
            Debug.Log(m_SpaceCreations[0].m_Level);
            Debug.Log(m_SpaceCreations[0].m_CreatPower);
            Debug.Log(m_SpaceCreations[0].m_Name);
            Debug.Log(m_SpaceCreations[0].m_NextLevelCost);
            Debug.Log(m_SpaceCreations[0].m_Tier);
        }
    }
    public void StatusUpdate()
    {
        for (int i = 0; i < m_SpaceCreations.Length; i++)
        {
            m_SpaceCreations[i].StatusUpdate();
        }
    }
    public void LevelUp(SpaceCreation _creation)
    {
        _creation.m_Level++;
        StatusUpdate();
    }
}
