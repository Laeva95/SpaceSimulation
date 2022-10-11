using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier7 : SpaceCreation
{
    public SpaceCreationTier7(int _level, int _tier)
    {
        m_Name = "Galaxy";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = (ulong)m_Level * 1000000;
        m_NextLevelCost = (ulong)(10000000000000 * Mathf.Pow(m_Level + 1, 1.25f) * (int)Mathf.Pow(2, (int)(0.04f * (m_Level + 1))));
    }
}
