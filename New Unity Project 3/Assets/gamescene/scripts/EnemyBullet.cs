using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    Rigidbody2D Rigid2D;
    public float Bulletspeed;

    // Use this for initialization
    void Start () {
        Rigid2D = GetComponent<Rigidbody2D>();
        Rigid2D.velocity = transform.TransformDirection(Vector3.up) * Bulletspeed;

        Destroy(gameObject, 5);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
