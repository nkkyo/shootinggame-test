using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Bullet : MonoBehaviour {

    public static int L_damege =  3;

    SpriteRenderer Renderer;
    Rigidbody2D Rigid2D;
    GameObject Player;
    Player script;
    public bool a = true;

	// Use this for initialization
	void Start () {
        Renderer = GetComponent<SpriteRenderer>();
        Rigid2D = GetComponent<Rigidbody2D>();
        script = GameObject.FindWithTag("Player").GetComponent<Player>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z)&&a==true)
        {
            Player = GameObject.FindWithTag("Player");
            if(Player!=null)transform.position = Player.transform.position + new Vector3(0, 0.07f);
            if (Renderer.size.y < 15 && Player!=null)
            {
                Renderer.size = new Vector2(Renderer.size.x, Renderer.size.y + 0.5f);

            }
        }
        if (Input.GetKeyUp(KeyCode.Z)|| script.playerstate != global::Player.Playerstate.laser||Player==null)
        {
            Rigid2D.velocity = new Vector2(0, 30);
            Destroy(gameObject, 1);
            a = false;
            
        }
            
	}



   
}
