using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemmove : MonoBehaviour {

    stage stagescript;
    float speed;

	// Use this for initialization
	void Start () {
        GameObject map = GameObject.FindWithTag("map");
        stagescript = map.GetComponent<stage>();
        speed = stagescript.speed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed, 0);
	}
}
