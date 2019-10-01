using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script2 : MonoBehaviour {

    public AudioClip clip;

    private AudioSource source;


	// Use this for initialization
	void Start () {

        source = GetComponent<AudioSource>();


	}


   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy2")
        {

            
            source.PlayOneShot(clip, 1.0f);
        }
    }
}
