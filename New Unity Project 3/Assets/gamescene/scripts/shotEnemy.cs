using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotEnemy : MonoBehaviour {

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
        Enemybullet = (GameObject)Resources.Load("Enemybullet");
        Rigid2D.velocity = transform.TransformDirection(Vector3.down) * speed;
}
	
	// Update is called once per frame
	void Update () {
        Shotspan -= Time.deltaTime;
        if (Shotspan <= 0) {
            Instantiate(Enemybullet, transform.position,
                Quaternion.Euler(0, 0, transform.localEulerAngles.z+225));
            //自機の角度を取得する際はtransform.localEulerAnglesを利用するtransform.localrotationはダメ
            Instantiate(Enemybullet, transform.position,
                Quaternion.Euler(0, 0, transform.localEulerAngles.z + 180));
            Instantiate(Enemybullet, transform.position,
                Quaternion.Euler(0, 0, transform.localEulerAngles.z + 135));
            Shotspan = 2;
        }


    }
}
