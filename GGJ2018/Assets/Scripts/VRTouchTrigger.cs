using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTouchTrigger : MonoBehaviour
{
    private GameManager m_gm;

    public GameObject grabbedObj;
    private GameObject object2Grab;

    public OVRInput.Button btn;

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

        if(OVRInput.GetDown(btn) && grabbedObj == null && object2Grab != null)
        {
            grabbedObj = object2Grab;
            object2Grab.GetComponent<Rigidbody>().isKinematic = true;
            object2Grab.transform.parent = this.transform;
        }
        else if (OVRInput.GetDown(btn) && grabbedObj != null)
        {
            grabbedObj.transform.parent = null;
            grabbedObj.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObj = null;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 8 && grabbedObj == null)
        {
            object2Grab = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == object2Grab)
        {
            object2Grab = null;
        }
    }
}
