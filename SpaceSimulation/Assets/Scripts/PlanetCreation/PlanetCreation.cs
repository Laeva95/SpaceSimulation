using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetCreation
{
    public string m_Name;
    public int m_Level;
    public ulong m_DivinityPower;
    public ulong m_NextLevelCost;
    public int m_Tier;

    public abstract void StatusUpdate();
}
