using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    private Animator m_a;

    private void Awake()
    {
        m_a = GetComponent<Animator>();
        UnityEngine.XR.XRSettings.enabled = false;
    }

    private void Update()
    {
        if (m_a.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            Application.LoadLevel("testings");
    }
}
