using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuibiEnemy : MonoBehaviour {

    Rigidbody2D Rigid2D;
    GameObject target;
    Vector2 tagpos;
    public float speed;

	// Use this for initialization
	void Start () {
        Rigid2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        StartCoroutine(Tuibi()); //一定時間ごとに追跡させる場合は時間を設定した後start関数にこれを入力
    }
	
	// Update is called once per frame
	void Update () {
       
    }


    IEnumerator Tuibi() {
        while (true) { yield return new WaitForSeconds(0.0f);
            tagpos = new Vector2(0, 0);

            if (target == null) { target = GameObject.FindWithTag("Player");}
            else tagpos = target.transform.position;
            //target==nullはプレイヤーが撃破されたときにプレイヤーがいない為座標を特定できない
            //エラーを防ぐためのもの
            if (tagpos != new Vector2(0, 0))
            {
                Vector2 dir =
                  tagpos - new Vector2(transform.position.x, transform.position.y);
                dir = dir.normalized;

                // Rigid2D.velocity = transform.TransformDirection(dir) * speed;

                transform.localRotation = Quaternion.FromToRotation(Vector3.down, dir);
            }
            Rigid2D.velocity = transform.TransformDirection(Vector3.down) * speed;
        }
    }
}
