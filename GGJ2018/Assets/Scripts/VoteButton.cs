using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteButton : MonoBehaviour
{
    public ButtonType bType;

    private GameManager m_gm;

    private Color m_originalColor;
    private Renderer m_renderer;

    [SerializeField]
    private AudioSource m_as;

    private void Awake()
    {
        m_gm = FindObjectOfType<GameManager>();
        m_originalColor = GetComponent<Renderer>().material.color;
        m_renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VRTouchTrigger>())
            OnMouseDown();
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<VRTouchTrigger>())
            OnMouseDown();
    }*/

    private void OnMouseDown()
    {
        if(!m_gm.waitingForNext)
        {
            m_gm.MakeJudgement(bType);
            m_as.Play();
        }     
    }

    private void OnMouseEnter()
    {
        //if (m_gm.makingJudgement && !m_gm.madeJudgement)
        if (!m_gm.waitingForNext)
            m_renderer.material.color = Color.white;
    }

    private void OnMouseExit()
    {
        m_renderer.material.color = m_originalColor;
    }
}

public enum ButtonType
{
    Yes,
    No
}
