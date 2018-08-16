using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmscript : MonoBehaviour {

    AudioSource[] audios;
    int num=0;

	// Use this for initialization
	void Start () {
        audios = GetComponents<AudioSource>();
       // audios[0].Play();
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
