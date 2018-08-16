using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latetuibi : MonoBehaviour {
    Rigidbody2D Rigid2D;
    public GameObject target;
    Vector2 tagpos;

   
    public float speed;
    bool a = false;

    // Use this for initialization
    void Start()
    {
        Rigid2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        StartCoroutine(Tuibi()); //一定時間ごとに追跡させる場合は時間を設定した後start関数にこれを入力
        Rigid2D.velocity = transform.TransformDirection(Vector3.down) * speed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    IEnumerator Tuibi()
    {
        while (true && a==false)
        {
            yield return new WaitForSeconds(1);

            if (target == null) { target = GameObject.FindWithTag("Player"); }
            else tagpos = target.transform.position;

            Vector2 dir =
              tagpos - new Vector2(transform.position.x, transform.position.y);
            dir = dir.normalized;

            // Rigid2D.velocity = transform.TransformDirection(dir) * speed;

            transform.localRotation = Quaternion.FromToRotation(Vector3.down, dir);
            Rigid2D.velocity = transform.TransformDirection(Vector3.down) * speed;
            a = true;
        }
    }
}
