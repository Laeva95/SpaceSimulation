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
    UIBtnManager m_UI;
    ShopUpgrade m_Shop;
    StringBuilder m_Sb = new StringBuilder();
    public TouchManager Touch
    {
        get;
        private set;
    }
    public ulong CreatePower = 0;
    public ulong DivinityPower = 0;
    public ulong RebirthPoint = 0;
    public ulong TotalCP = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Touch = new TouchManager(this);
        m_UI = FindObjectOfType<UIBtnManager>();
        m_Shop = FindObjectOfType<ShopUpgrade>();
    }
    public void UpdateText()
    {
        m_Sb.Clear();
        m_Sb.Append($"CP: {Utils.Caculation(CreatePower)}(+{Utils.Caculation(CPCal())}/s)\n");
        m_Sb.Append($"DP: {Utils.Caculation(DivinityPower)}(+{Utils.Caculation(DPCal())}/s)\n");
        m_Sb.Append($"RP: {Utils.Caculation(RebirthPoint)}");

        m_TopText.text = m_Sb.ToString();
        m_UI.RebirthTextUpdate();
        m_Shop.UpdateText();
    }
    ulong CPCal()
    {
        return m_SpaceManager.m_TotalCreatePower 
            * (ulong)(1 + m_RelicManager.m_Relics[0].m_Level + (m_RelicManager.m_Relics[4].m_Level * 2))
            * (ulong)(1 + m_Shop.m_ShopLevel[0]);
    }
    ulong DPCal()
    {
        return m_PlanetManager.m_TotalDivinityPower 
            * (ulong)(1 + m_RelicManager.m_Relics[1].m_Level + (m_RelicManager.m_Relics[5].m_Level * 2))
            * (ulong)(1 + m_Shop.m_ShopLevel[1]);
    }

    #region 해상도 조절
    public void SetResolution()
    {
        int setWidth = 900; // 사용자 설정 너비
        int setHeight = 1900; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
    #endregion
}
