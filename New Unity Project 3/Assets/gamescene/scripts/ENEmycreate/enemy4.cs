using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy4 : MonoBehaviour {

    public static int enemycount { get; set; }
    public int enemynum;
    

    public GameObject[] enemy=new GameObject[enemycount];
    public float[] span = new float[enemycount] ;
    public Vector3[] point=new Vector3[enemycount];
    public int[] kakudo =new int[enemycount];
    int index = 0;
    int count = 0;

    // Use this for initialization
    void Start () {
        enemycount = enemynum;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator create()
    {

        for (int i = 0; i < enemy.Length; i++)
        {
            // point[i] = Camera.main.ViewportToWorldPoint(
            // new Vector2(enemypointx[i], enemypointy[i]));
            Instantiate(enemy[i], Camera.main.ViewportToWorldPoint(point[i] + new Vector3(0, 0, 1))
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
