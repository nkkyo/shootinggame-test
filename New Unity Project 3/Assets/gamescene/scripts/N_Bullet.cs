using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Bullet : MonoBehaviour {

    public static int N_damege = 2;

    Rigidbody2D Rigid2D;
    public float Bulletspeed;

	// Use this for initialization
	void Start () {
        Rigid2D = GetComponent<Rigidbody2D>();
        Rigid2D.velocity = new Vector2(0, Bulletspeed);
        Destroy(gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
