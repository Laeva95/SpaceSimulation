using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationTier1 : PlanetCreation
{
    public PlanetCreationTier1(int _level, int _tier)
    {
        m_Name = "Plant";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_DivinityPower = (ulong)m_Level * 25;
        m_NextLevelCost = (ulong)(10000 * Mathf.Pow(m_Level + 1, 1.5f) * (int)Mathf.Pow(2, (int)(0.1f * (m_Level))));
    }
}
