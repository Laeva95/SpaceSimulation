using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier5 : SpaceCreation
{
    public SpaceCreationTier5(int _level, int _tier)
    {
        m_Name = "Sun";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = (ulong)m_Level * 15000;
        m_NextLevelCost = (ulong)(100000000 * Mathf.Pow(m_Level + 1, 1.25f) * (int)Mathf.Pow(2, (int)(0.04f * (m_Level + 1))));
    }
}
