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

    #region �ػ� ����
    public void SetResolution()
    {
        int setWidth = 900; // ����� ���� �ʺ�
        int setHeight = 1900; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }
    #endregion
}
