using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier2 : SpaceCreation
{
    public SpaceCreationTier2(int _level, int _tier)
    {
        m_Name = "Comet";
        m_Tier = _tier;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = (ulong)m_Level * 30;
        m_NextLevelCost = (ulong)(1000 * Mathf.Pow(m_Level + 1, 1.25f) * (int)Mathf.Pow(2, (int)(0.04f * (m_Level + 1))));
    }
}
