using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_bullet : MonoBehaviour {

    public static int W_damege = 3;

    Rigidbody2D Rigid2D;
    public float Bulletspeed;
   

    // Use this for initialization
    void Start () {
        Rigid2D = GetComponent<Rigidbody2D>();
        // Rigid2D.velocity = new Vector2(0, Bulletspeed);
        Rigid2D.velocity = transform.TransformDirection(Vector3.up) * Bulletspeed;
       
        Destroy(gameObject, 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
