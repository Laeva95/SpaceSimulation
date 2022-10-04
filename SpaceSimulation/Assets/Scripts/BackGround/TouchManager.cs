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
        Resource.UpdateText();
    }
    public void SetTouchCreatePowerIncrease(ulong _increase)
    {
        TouchCreatePowerIncrease = 1 + (ulong)(_increase * 0.2f);
    }
    public void GetTouchPlanetBackgound()
    {
        Resource.DivinityPower += TouchDivinityPowerIncrease;
        Resource.UpdateText();
    }
    public void SetTouchDivinityPowerIncrease(ulong _increase)
    {
        TouchDivinityPowerIncrease = 1 + (ulong)(_increase * 0.2f);
    }
}
