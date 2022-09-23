using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationTier3 : PlanetCreation
{
    public PlanetCreationTier3(int _level, int _tier)
    {
        m_Name = "Birds";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_DivinityPower = (ulong)m_Level * 250;
        m_NextLevelCost = (ulong)(10000 * Mathf.Pow(m_Level + 1, 1.25f) * (int)(1 + 0.1f * (m_Level + 1)));
    }
}