using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationTier5 : PlanetCreation
{
    public PlanetCreationTier5(int _level, int _tier)
    {
        m_Name = "Human";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_DivinityPower = (ulong)m_Level * 100000;
        m_NextLevelCost = (ulong)(1000000000000 * Mathf.Pow(m_Level + 1, 1.5f) * (int)Mathf.Pow(2, (int)(0.1f * (m_Level))));
    }
}
