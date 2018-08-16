using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour {

    public int tokuten;
    Score score;
    EnemyDamege enemydamege;

	// Use this for initialization
	void Start () {
        enemydamege = GetComponent<EnemyDamege>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

	}
	
	// Update is called once per frame
	void Update () {
        if (enemydamege.HP <= 0) {
            
        }
	}
}
