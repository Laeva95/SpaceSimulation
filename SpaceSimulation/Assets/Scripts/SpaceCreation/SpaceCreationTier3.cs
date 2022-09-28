using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier3 : SpaceCreation
{
    public SpaceCreationTier3(int _level, int _tier)
    {
        m_Name = "Satellite";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = (ulong)m_Level * 250;
        m_NextLevelCost = (ulong)(25000 * Mathf.Pow(m_Level + 1, 1.5f) * (int)(1 + 0.04f * (m_Level + 1)));
    }
}
