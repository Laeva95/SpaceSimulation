using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier1 : SpaceCreation
{
    public SpaceCreationTier1(int _level, int _tier)
    {
        m_Name = "Star";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = (ulong)m_Level * 5;
        m_NextLevelCost = (ulong)(100 * Mathf.Pow(m_Level + 1, 1.25f) * (int)(1 + 0.04f * (m_Level + 1)));
    }
}
