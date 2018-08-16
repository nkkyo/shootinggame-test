using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycreate3 : MonoBehaviour {

    public GameObject[] enemy;
    public float[] span;
    public Vector3[] point;
    public int[] kakudo;
    int index = 0;
    int count = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator create() {

        for (int i = 0; i < enemy.Length; i++)
        {
            // point[i] = Camera.main.ViewportToWorldPoint(
            // new Vector2(enemypointx[i], enemypointy[i]));
            Instantiate(enemy[i], Camera.main.ViewportToWorldPoint(point[i]+ new Vector3(0,0,1) ) 
                //+Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 1))//これがないとｚ座標が-15で生成されて画面に表示されなくなる
                , Quaternion.Euler(0, 0, kakudo[i])
                );

            yield return new WaitForSeconds(span[i]);
        }
         
         
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera") StartCoroutine(create());
    }
}
