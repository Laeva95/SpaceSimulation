using UnityEngine;
using System.Text;

public class PlayerResourceManager : MonoBehaviour
{
    public SpaceBackGround m_SpaceBackGround;
    public PlanetBackGround m_PlanetBackGround;
    public SpaceCreationManager m_SpaceManager;
    public PlanetCreationManager m_PlanetManager;
    public RelicManager m_RelicManager;
    public UnityEngine.UI.Text m_TopText;
    StringBuilder m_Sb = new StringBuilder();
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
    }
    public void UpdateText()
    {
        m_Sb.Clear();
        m_Sb.Append($"CP: {Utils.Caculation(CreatePower)}(+{Utils.Caculation(CPCal())}/s)\n");
        m_Sb.Append($"DP: {Utils.Caculation(DivinityPower)}(+{Utils.Caculation(DPCal())}/s)\n");
        m_Sb.Append($"RP: {Utils.Caculation(RebirthPoint)}");

        m_TopText.text = m_Sb.ToString();
    }
    ulong CPCal()
    {
        return m_SpaceManager.m_TotalCreatePower 
            * (ulong)(1 + m_RelicManager.m_Relics[0].m_Level + (m_RelicManager.m_Relics[4].m_Level * 2));
    }
    ulong DPCal()
    {
        return m_PlanetManager.m_TotalDivinityPower 
            * (ulong)(1 + m_RelicManager.m_Relics[1].m_Level + (m_RelicManager.m_Relics[5].m_Level * 2));
    }
}
