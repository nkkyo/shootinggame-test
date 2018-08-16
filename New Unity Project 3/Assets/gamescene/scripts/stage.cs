using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage : MonoBehaviour {

    public float speed= -0.005f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed, 0);
	}
}
