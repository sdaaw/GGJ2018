using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTouchTrigger : MonoBehaviour
{
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
            FindObjectOfType<GameManager>().StartTrial(20);
    }
}
