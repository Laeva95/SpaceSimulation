using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationTier4 : PlanetCreation
{
    public PlanetCreationTier4(int _level, int _tier)
    {
        m_Name = "Mammalia";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_DivinityPower = (ulong)m_Level * 2000;
        m_NextLevelCost = (ulong)(100000 * Mathf.Pow(m_Level + 1, 1.25f) * (int)(1 + 0.1f * (m_Level + 1)));
    }
}
