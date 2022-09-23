using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public SpaceBackGround m_SpaceBackGround;
    public PlanetBackGround m_PlanetBackGround;
    public TouchManager Touch
    {
        get;
        private set;
    }
    public ulong CreatePower = 0;
    public ulong DivinityPower = 0;

    public PlayerResourceManager()
    {
        Touch = new TouchManager(this);
    }
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
}
