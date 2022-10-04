using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public SpaceBackGround m_SpaceBackGround;
    public PlanetBackGround m_PlanetBackGround;
    public SpaceCreationManager m_SpaceManager;
    public PlanetCreationManager m_PlanetManager;
    public RelicManager m_RelicManager;
    public UnityEngine.UI.Text m_TopText;
    public TouchManager Touch
    {
        get;
        private set;
    }
    public ulong CreatePower = 0;
    public ulong DivinityPower = 0;
    public ulong RebirthPoint = 0;

    public PlayerResourceManager()
    {
        Touch = new TouchManager(this);
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
        CreatePower = 10000000000000;
        DivinityPower = 10000000000000;
        RebirthPoint = 10000;
    }
    public void UpdateText()
    {
        m_TopText.text = $"CP: {Utils.Caculation(CreatePower)}(+{Utils.Caculation(m_SpaceManager.m_TotalCreatePower * (ulong)(1 + m_RelicManager.m_Relics[0].m_Level))}/s)\n" +
            $"DP: {Utils.Caculation(DivinityPower)}(+{Utils.Caculation(m_PlanetManager.m_TotalDivinityPower * (ulong)(1 + m_RelicManager.m_Relics[1].m_Level))}/s)\n" +
            $"RP: {Utils.Caculation(RebirthPoint)}";
    }
}
