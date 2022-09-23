using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCreationTier0 : PlanetCreation
{
    public PlanetCreationTier0(int _level, int _tier)
    {
        m_Name = "Rock";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_DivinityPower = (ulong)m_Level * 1;
        m_NextLevelCost = (ulong)(10 * Mathf.Pow(m_Level + 1, 1.25f) * (int)(1 + 0.1f * (m_Level + 1)));
    }
}