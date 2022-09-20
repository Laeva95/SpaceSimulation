using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCreationTier0 : SpaceCreation
{
    public SpaceCreationTier0(int _level)
    {
        m_Name = "StarDust";
        m_Tier = 0;

        m_Level = _level;
        StatusUpdate();
    }
    public override void StatusUpdate()
    {
        m_CreatPower = m_Level * 1;
        m_NextLevelCost = 10 * (m_Level + 1) * (m_Level + 1);
    }
}
