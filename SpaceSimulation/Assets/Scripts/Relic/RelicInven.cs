using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RelicInven : MonoBehaviour
{
    [SerializeField]
    private RelicManager m_RelicManager;
    [SerializeField]
    private PlayerResourceManager m_Resource;
    [SerializeField]
    private Button m_GetRelicBtn;
    [SerializeField]
    private Text m_GetRelicCostText;
    [SerializeField]
    private Text m_RelicCountText;

    private int m_RelicCount;
    private int m_RelicCost;
    private bool m_Valid;



    public void GetRelic()
    {
        if (m_Resource.RebirthPoint >= (ulong)m_RelicCost)
        {
            m_Resource.RebirthPoint -= (ulong)m_RelicCost;

            Relic relic;

            while (true)
            {
                relic = m_RelicManager.m_Relics[Random.Range(0, m_RelicManager.m_Relics.Length)];
                if (relic.m_Level == 0)
                {
                    break;
                }
            }
            relic.LevelUpBtn();
        }

        ValidCheck();
    }
    public void ValidCheck()
    {
        m_Valid = false;
        m_RelicCount = 0;

        for (int i = 0; i < m_RelicManager.m_Relics.Length; i++)
        {
            if (m_RelicManager.m_Relics[i].m_Level == 0)
            {
                m_Valid = true;
            }
            else
            {
                m_RelicCount++;
            }
        }
        m_RelicCost = ((int)Mathf.Pow(2, m_RelicCount) * 100);
        m_GetRelicCostText.text = m_Valid ? m_RelicCost.ToString() + " RP" : "Max";
        m_RelicCountText.text = m_RelicCount.ToString() + " Relics";
        m_GetRelicBtn.interactable = m_Valid;
    }
    public void RelicLevenUp(Relic _relic)
    {
        if (!_relic.gameObject.activeSelf)
        {
            _relic.gameObject.SetActive(true);
        }
        _relic.m_Level++;
        m_RelicManager.UpdateText(_relic);
        m_Resource.UpdateText();
    }
}
