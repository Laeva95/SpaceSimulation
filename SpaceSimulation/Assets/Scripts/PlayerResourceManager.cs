using UnityEngine;

public class PlayerResourceManager
{
    public TouchManager Touch
    {
        get;
        private set;
    }
    public int CreatePower = 0;
    //public int CreatePower
    //{
    //    get
    //    { return PlayerPrefs.GetInt("Creation", 0); }
    //    set
    //    { PlayerPrefs.SetInt("Creation", value); }
    //}

    public PlayerResourceManager()
    {
        Touch = new TouchManager(this);
    }
}
