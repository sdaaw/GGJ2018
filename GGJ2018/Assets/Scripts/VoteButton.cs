using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteButton : MonoBehaviour
{
    public ButtonType bType;

    private GameManager m_gm;

    private Color m_originalColor;

    private void Awake()
    {
        m_gm = FindObjectOfType<GameManager>();
        m_originalColor = GetComponent<Renderer>().material.color;
    }

    private void OnMouseDown()
    {
        if(m_gm.makingJudgement && !m_gm.madeJudgement)
            m_gm.MakeJudgement(bType);
    }

    private void OnMouseEnter()
    {
        if (m_gm.makingJudgement && !m_gm.madeJudgement)
            GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = m_originalColor;
    }
}

public enum ButtonType
{
    Yes,
    No
}
