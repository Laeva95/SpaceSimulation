using UnityEngine;

public class TouchManager
{
    public ulong TouchCreatePowerIncrease
    {
        get;
        private set;
    }
    public ulong TouchDivinityPowerIncrease
    {
        get;
        private set;
    }
    public PlayerResourceManager Resource
    {
        get;
        private set;
    }

    public TouchManager(PlayerResourceManager _resource)
    {
        Resource = _resource;
        TouchCreatePowerIncrease = 1;
        TouchDivinityPowerIncrease = 1;
    }
    public void GetTouchSpaceBackgound()
    {
        Resource.CreatePower += TouchCreatePowerIncrease;
    }
    public void SetTouchCreatePowerIncrease(ulong _increase)
    {
        TouchCreatePowerIncrease = 1 + (ulong)(_increase * 0.1f);
    }
    public void GetTouchPlanetBackgound()
    {
        Resource.DivinityPower += TouchDivinityPowerIncrease;
    }
    public void SetTouchDivinityPowerIncrease(ulong _increase)
    {
        TouchDivinityPowerIncrease = 1 + (ulong)(_increase * 0.1f);
    }
}
