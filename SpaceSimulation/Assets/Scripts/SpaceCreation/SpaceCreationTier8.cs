using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier8 : SpaceCreation
{
    public SpaceCreationTier8(int _level, int _tier)
    {
        m_Name = "Space";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = (ulong)m_Level * 10000000;
        m_NextLevelCost = (ulong)(10000000000000 * Mathf.Pow(m_Level + 1, 1.5f) * (int)(1 + 0.04f * (m_Level + 1)));
    }
}
