using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbullet3 : MonoBehaviour {

    [SerializeField, Range(0, 10)]
    float time = 1;

    [SerializeField]
    public Vector2 endPosition;

    [SerializeField]
    AnimationCurve curve;
    Rigidbody2D rigid2d;
    [SerializeField] float speed;

    private float startTime;
    private Vector3 startPosition;

   

    void OnEnable()
    {
       
        /*if (time <= 0)
        {
            transform.position = endPosition;
            enabled = false;
            return;
        }*/

        startTime = Time.timeSinceLevelLoad;
        startPosition =Camera.main.WorldToViewportPoint (transform.position);
        Invoke("falling", time + 0.5f);
    }

    void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff < time)
        {
            var rate = diff / time;
            var pos = curve.Evaluate(rate);

            //transform.position = Vector3.Lerp(Camera.main.ViewportToWorldPoint(startPosition) + new Vector3(0, 0, 1)
            //    , Camera.main.ViewportToWorldPoint(endPosition) + new Vector3(0, 0, 1), rate);
            transform.position = Vector3.Lerp (Camera.main.ViewportToWorldPoint(startPosition) + new Vector3(0, 0, 1)
                 , Camera.main.ViewportToWorldPoint(endPosition) + new Vector3(0, 0, 1), pos);
        }




    }

    void falling()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        rigid2d.velocity = new Vector2(0, speed);
       
    }
}
