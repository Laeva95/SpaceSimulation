using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public static PlayerResourceManager instance;
    public static PlayerResourceManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }
    public int Creation
    {
        get
        { return PlayerPrefs.GetInt("Creation", 0); }
        set
        { PlayerPrefs.SetInt("Creation", value); }
    }

    public int m_TouchIncrease;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SetTouchIncrease();
    }

    public void GetTouchBackgound()
    {
        Creation += m_TouchIncrease;

        Debug.Log(Creation);
    }
    void SetTouchIncrease()
    {
        m_TouchIncrease = 1;
    }
}
