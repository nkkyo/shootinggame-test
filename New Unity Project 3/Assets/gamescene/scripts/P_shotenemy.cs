using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_shotenemy : MonoBehaviour {

    Rigidbody2D Rigid2D;
    GameObject target;
    Vector2 tagpos;
    public float speed;
    float Shotspan = 2;
    GameObject Enemybullet;

    // Use this for initialization
    void Start () {
        Rigid2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        Enemybullet = (GameObject)Resources.Load("Enemybullet2");
        Rigid2D.velocity = transform.TransformDirection(Vector3.down)*speed;
    }
	
	// Update is called once per frame
	void Update () {
        Shotspan -= Time.deltaTime;
        if (Shotspan <= 0)
        {
            if (target == null) { target = GameObject.FindWithTag("Player"); }
            else tagpos = target.transform.position;
            var dir = tagpos - new Vector2(transform.position.x, transform.position.y);
            dir = dir.normalized;
            Instantiate(Enemybullet, transform.position,
               Quaternion.FromToRotation(Vector3.up, dir));
           
            Shotspan = 2;
        }
    }
}
