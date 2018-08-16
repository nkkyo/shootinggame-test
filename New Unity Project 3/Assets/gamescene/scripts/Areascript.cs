using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areascript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 5 ||
            other.gameObject.tag == "L_shot") { }
        else Destroy(other.gameObject);
    }
}
