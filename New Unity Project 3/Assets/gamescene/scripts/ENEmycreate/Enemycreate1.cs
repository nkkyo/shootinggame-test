using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycreate1 : MonoBehaviour {

    public GameObject enemy;
    GameObject map;
    public int enemycount;
    Vector2 point;
    public float basyox;
    int count = 0;

	// Use this for initialization
	void Start () {
       
       
	}
	
	// Update is called once per frame
	void Update () {
        map = GameObject.FindWithTag("map");
        point = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 1));
    }

    IEnumerator create() {
        while (count != enemycount)
        {
            Instantiate(enemy, point+new Vector2(basyox,0), Quaternion.identity);
            count++;

            yield return new WaitForSeconds(0.5f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.tag=="MainCamera") StartCoroutine(create());
    }
}
