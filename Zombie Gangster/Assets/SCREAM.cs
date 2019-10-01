using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCREAM : MonoBehaviour {

    private AudioSource source;

    public AudioClip[] clip;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if(Input.)
    }

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            source.PlayOneShot(clip[0], 1.0f);
        }
        if (other.tag == "Enemy" || other.tag == "Enemy2")
        {
            source.PlayOneShot(clip[1], 0.5f);
        }
    }
    
}
