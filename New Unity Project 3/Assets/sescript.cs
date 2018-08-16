using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sescript : MonoBehaviour {

    public AudioClip playershot, explo,Lshot,Wshot,enemyshot,bossexplo,bossshot;
    public AudioSource source;
   

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
