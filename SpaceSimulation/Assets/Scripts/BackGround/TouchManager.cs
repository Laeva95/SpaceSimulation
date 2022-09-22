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

        Debug.Log(Resource.CreatePower);
    }
    public void SetTouchCreatePowerIncrease(ulong _increase)
    {
        TouchCreatePowerIncrease = 1 + _increase;
    }
    public void GetTouchPlanetBackgound()
    {
        Resource.DivinityPower += TouchDivinityPowerIncrease;

        Debug.Log(Resource.DivinityPower);
    }
    public void SetTouchDivinityPowerIncrease(ulong _increase)
    {
        TouchDivinityPowerIncrease = 1 + _increase;
    }
}
