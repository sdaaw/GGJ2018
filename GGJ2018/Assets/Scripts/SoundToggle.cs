using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour {


    public AudioSource audioClip;

    public bool isOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(isOn == true)
        {
            PlayAudio();
        }
	}

    void PlayAudio()
    {
        audioClip.Play();
        isOn = false;
    }

}
