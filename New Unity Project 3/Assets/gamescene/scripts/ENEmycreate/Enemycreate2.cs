using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycreate2 : MonoBehaviour {

    public GameObject enemy;
    GameObject map;
    public int enemycount;
    Vector2 point;
    int count = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        map = GameObject.FindWithTag("map");
        point = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1));
    }

    IEnumerator create()
    {
        while (count != enemycount)
        {
            Instantiate(enemy, point+new Vector2(5,0), Quaternion.identity);
            Instantiate(enemy, point , Quaternion.identity);
            Instantiate(enemy, point + new Vector2(-5, 0), Quaternion.identity);

            count +=3;

            yield return new WaitForSeconds(2);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCamera") StartCoroutine(create());
    }
}
