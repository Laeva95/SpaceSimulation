using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationTier2 : PlanetCreation
{ 
    public PlanetCreationTier2(int _level, int _tier)
    {
        m_Name = "Reptile";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_DivinityPower = (ulong)m_Level * 25;
        m_NextLevelCost = (ulong)(25000 * Mathf.Pow(m_Level + 1, 1.5f) * (int)(1 + 0.1f * (m_Level + 1)));
    }
}
