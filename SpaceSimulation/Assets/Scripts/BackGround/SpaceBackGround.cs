using UnityEngine;

public class SpaceBackGround : MonoBehaviour
{
    public Vector3 m_StartPos;
    [SerializeField]
    private Camera m_MainCamera;

    public PlayerResourceManager m_Resource;

    private void Awake()
    {
    }

    private void OnMouseDown()
    {
        m_Resource.Touch.GetTouchSpaceBackgound();
        m_StartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, -10));
    }

    private void OnMouseDrag()
    {
        if (m_StartPos != Vector3.zero)
        {
            Vector3 dragPos = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,
                0, -10));

            m_MainCamera.transform.position = Vector3.Lerp
                (m_MainCamera.transform.position,
                m_MainCamera.transform.position + (m_StartPos - dragPos),
                0.05f);
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
