using UnityEngine;

public class TouchManager
{
    public int TouchIncrease
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
        TouchIncrease = 1;
    }
    public void GetTouchBackgound()
    {
        Resource.CreatePower += TouchIncrease;

        Debug.Log(Resource.CreatePower);
    }
}
