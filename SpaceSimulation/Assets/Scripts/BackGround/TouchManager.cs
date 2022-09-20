using UnityEngine;

public class TouchManager
{
    public int TouchCreatePowerIncrease
    {
        get;
        private set;
    }
    public int TouchDivinityPowerIncrease
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
    public void SetTouchCreatePowerIncrease(int _increase)
    {
        TouchCreatePowerIncrease = 1 + _increase;
    }
    public void GetTouchPlanetBackgound()
    {
        Resource.DivinityPower += TouchDivinityPowerIncrease;

        Debug.Log(Resource.DivinityPower);
    }
    public void SetTouchDivinityPowerIncrease(int _increase)
    {
        TouchDivinityPowerIncrease = 1 + _increase;
    }
}
