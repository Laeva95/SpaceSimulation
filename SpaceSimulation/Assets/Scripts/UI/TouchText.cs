using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchText : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_CPTextObj;
    [SerializeField]
    GameObject[] m_DPTextObj;

    public void GetCPTextObj()
    {
        for (int i = 0; i < m_CPTextObj.Length; i++)
        {
            if (m_CPTextObj[i].activeSelf)
            {
                continue;
            }
            m_CPTextObj[i].SetActive(true);
            return;
        }
    }    
    public void GetDPTextObj()
    {
        for (int i = 0; i < m_DPTextObj.Length; i++)
        {
            if (m_DPTextObj[i].activeSelf)
            {
                continue;
            }
            m_DPTextObj[i].SetActive(true);
            return;
        }
    }
}
