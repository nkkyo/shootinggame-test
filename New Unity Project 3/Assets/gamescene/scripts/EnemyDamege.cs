using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamege : MonoBehaviour {

    public int HP;
    SpriteRenderer sp;
    GameObject explo;
    public int tokuten;
    Score score;
    bool gekiha=false;
    sescript se;
   

    // Use this for initialization
    void Start () {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        sp = GetComponent<SpriteRenderer>();
        explo = (GameObject)Resources.Load("explo");
        se = GameObject.FindGameObjectWithTag("se").GetComponent<sescript>();
	}
	
	// Update is called once per frame
	void Update () {

        if (HP <= 0)
        {

            if (!gekiha)
            {
                score.keisan(tokuten);
                gekiha = true;
            }
            if (gameObject.tag != "boss")
            {
                Instantiate(explo, transform.position, Quaternion.identity);
                se.source.PlayOneShot(se.explo);
                Destroy(gameObject);
            }
          


        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "N_shot") {
            Destroy(other.gameObject);
            HP -= N_Bullet.N_damege;
            StartCoroutine(hit());
           
        }


        if (other.gameObject.tag == "W_shot")
        {
            Destroy(other.gameObject);
            HP -= W_bullet.W_damege;
            StartCoroutine(hit());
        }

        if (other.gameObject.tag == "L_shot")
        {
            HP -= L_Bullet.L_damege;
            StartCoroutine(hit());
        }
    }

    IEnumerator hit() {
        sp.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.005f);
        sp.color = new Color(1, 1, 1, 1);
        yield break;
    }

  

}
