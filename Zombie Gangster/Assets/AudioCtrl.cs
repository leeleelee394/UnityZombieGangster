using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {

    private AudioSource Audio;
    public AudioClip Sound;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = Sound;
        Audio.Play();
        Debug.Log("칵퉤");
    }

}
