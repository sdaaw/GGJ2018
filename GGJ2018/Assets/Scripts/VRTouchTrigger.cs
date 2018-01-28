using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTouchTrigger : MonoBehaviour
{
    private GameManager m_gm;

    private void Awake()
    {
        m_gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && !m_gm.gameStarted)
        {
            m_gm.StartTrial(20);
            m_gm.gameStarted = true;
        }
        
        if (OVRInput.GetDown(OVRInput.Button.One) && m_gm.gameOver)
            Application.LoadLevel(Application.loadedLevel);
    }
}
