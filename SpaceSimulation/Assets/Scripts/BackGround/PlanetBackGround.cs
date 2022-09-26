using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBackGround : MonoBehaviour
{
    public Vector3 m_StartPos;
    [SerializeField]
    private Camera m_MainCamera;
    [SerializeField]
    private TouchText m_TouchText;

    public PlayerResourceManager m_Resource;


    private void OnMouseDown()
    {
        m_Resource.Touch.GetTouchPlanetBackgound();
        m_TouchText.GetDPTextObj();
        m_StartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, -10));
    }

    private void OnMouseDrag()
    {
        if (m_StartPos != Vector3.zero)
        {
            Vector3 dragPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                0, -10));

            m_MainCamera.transform.position = Vector3.Lerp
                (m_MainCamera.transform.position,
                m_MainCamera.transform.position + (m_StartPos - dragPos),
                0.2f);
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
