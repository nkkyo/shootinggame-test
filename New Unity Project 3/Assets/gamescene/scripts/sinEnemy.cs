using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinEnemy : MonoBehaviour {

    float sinx;
    public float speed;
    public float movey;
    public int yokonohayasa;
    float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        sinx = Mathf.Sin(time * yokonohayasa);
        transform.Translate(sinx * speed, movey, 0);
	}
}
