using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_StartPos;
    [SerializeField]
    private Camera m_MainCamera;

    private void OnMouseDown()
    {
        m_StartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, -10));
    }

    private void OnMouseDrag()
    {
        if (m_StartPos != Vector3.zero)
        {
            Vector3 dragPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,
                0, -10));

            m_MainCamera.transform.position = m_MainCamera.transform.position + (m_StartPos - dragPos);
        }

        CameraMoveLimitCheck();
    }
    private void OnMouseUp()
    {
        m_StartPos = Vector3.zero;
    }
    private void CameraMoveLimitCheck()
    {
        if (m_MainCamera.transform.position.x > 15)
        {
            m_MainCamera.transform.position = new Vector3(15, 0, -10);
        }
        else if (m_MainCamera.transform.position.x < -15)
        {
            m_MainCamera.transform.position = new Vector3(-15, 0, -10);
        }
    }
}
