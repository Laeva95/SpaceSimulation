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
    public int CreatePower = 0;
    public int DivinityPower = 0;

    public PlayerResourceManager()
    {
        Touch = new TouchManager(this);
    }
}
