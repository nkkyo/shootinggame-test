using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bossmove : MonoBehaviour {

    enum Bossstate {
        spawn,
        move,
       
    }

    Bossstate bossstate;

    Gemecon gamecon;
    EnemyDamege enemydamege;
    CircleCollider2D circoli;
    Rigidbody2D rigid2d;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject[] bullet3;
    public Vector2[] bulletposi;

    public GameObject[] bossexplode;
    
    fadascript fadasc;  
   

    public float turn;
    float check;
    public float spawnspeed;
    public float speed;
    public float hassyaposi;
    bool alive = true;
    bool atack=false;
    

	// Use this for initialization
	void Start () {
        gamecon = GameObject.FindWithTag("Respawn").GetComponent<Gemecon>();
        fadasc = GameObject.FindWithTag("fada").GetComponent<fadascript>();
        enemydamege = GetComponent<EnemyDamege>();
        circoli= GetComponent<CircleCollider2D>();
        bossstate = Bossstate.spawn;
        check = turn;
        rigid2d = GetComponent<Rigidbody2D>();
       

        bullet.transform.localScale = new Vector2(1.5f, 2.0f);
        bullet2.transform.localScale = new Vector2(1.0f, 2.0f);
       

        StartCoroutine("shot");
        
	}
	
	// Update is called once per frame
	void Update () {
        if (bossstate == Bossstate.spawn)
        {
            circoli.enabled = false;
        }
        else circoli.enabled = true;

        if (bossstate == Bossstate.move&& gamecon.gamestate != Gemecon.Gamestate.clear)
        {
            Vector2 limitleft = Camera.main.ViewportToWorldPoint(new Vector2(0.1f, 0));
            Vector2 limitright = Camera.main.ViewportToWorldPoint(new Vector2(0.9f, 0));

            check -= Time.deltaTime;
            if (check <= 0)
            {
                check = turn;
                int muki = Random.Range(1, 3);
                if (muki == 1) rigid2d.velocity = new Vector2(Random.Range(1, 6) * speed, 0);
                else rigid2d.velocity = new Vector2(Random.Range(1, 6) * -speed, 0);
            }

            if (transform.position.x >= limitright.x) rigid2d.velocity = new Vector2(Random.Range(1, 6) * -speed, 0);
            if (transform.position.x <= limitleft.x) rigid2d.velocity = new Vector2(Random.Range(1, 6) * speed, 0);

            if (atack == false)
            {
                int num = Random.Range(1, 4);
                switch (num)
                {
                    case 1:
                        StartCoroutine("atack1");
                        break;
                    case 2:
                        StartCoroutine("atack2");
                        break;
                    case 3:
                        StartCoroutine("atack3");
                        break;
                    default:
                        break;
                }

            }
        }
        else if (bossstate == Bossstate.spawn&& gamecon.gamestate != Gemecon.Gamestate.clear)
        {
            rigid2d.velocity = new Vector2(0, spawnspeed);
        }
        else if(gamecon.gamestate== Gemecon.Gamestate.clear) {
            rigid2d.velocity=new Vector2(0,0);
        }

        if (Camera.main.WorldToViewportPoint(transform.position).y <=0.8f ) {
            if (bossstate == Bossstate.spawn)
            {
                int muki = Random.Range(1, 3);
                if (muki == 1) rigid2d.velocity = new Vector2(Random.Range(1, 6) * speed, 0);
                else rigid2d.velocity = new Vector2(Random.Range(1, 6) * -speed, 0);
            }
           if(gamecon.gamestate != Gemecon.Gamestate.clear) bossstate = Bossstate.move;
        }

        if (enemydamege.HP <= 0 && gamecon.gamestate !=Gemecon.Gamestate.clear) {
            gamecon.gamestate =Gemecon.Gamestate.clear ;
            fadasc.StartCoroutine("second");
            StartCoroutine("bossexplo");
        }


    }

    IEnumerator shot() {
        yield return new WaitForSeconds(2f);
        while (alive) {
            if (gamecon.gamestate == Gemecon.Gamestate.clear) yield break;
            yield return new WaitForSeconds(1.0f);
            Instantiate(bullet, transform.position, Quaternion.Euler(0,0,180));
            yield return new WaitForSeconds(4.0f); } 
    }

    IEnumerator atack1() {
        atack = true;
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet1, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet1, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet1, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
       
        atack = false;
    }

    IEnumerator atack2() {
        atack = true;
        Instantiate(bullet2, new Vector3(0, hassyaposi) + transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(bullet2, new Vector3(0, hassyaposi) + transform.position, Quaternion.Euler(0, 0, 150));
        Instantiate(bullet2, new Vector3(0, hassyaposi) + transform.position, Quaternion.Euler(0, 0, 210));
        Instantiate(bullet2, new Vector3(0, hassyaposi-1f) + transform.position, Quaternion.Euler(0, 0, 180));
        Instantiate(bullet2, new Vector3(0, hassyaposi-1f) + transform.position, Quaternion.Euler(0, 0, 150));
        Instantiate(bullet2, new Vector3(0, hassyaposi-1f) + transform.position, Quaternion.Euler(0, 0, 210));
        yield return new WaitForSeconds(1.5f);

        atack = false;
    }

    IEnumerator atack3() {
        atack = true;
        for (int i = 0; i < bullet3.Length; i++)
        {
           GameObject b = Instantiate(bullet3[i], transform.position, Quaternion.identity)as GameObject;
            bossbullet3 boss = b.GetComponent<bossbullet3>();
            boss.endPosition = bulletposi[i];
        }


        yield return new WaitForSeconds(2f);
        atack = false;
    }

    IEnumerator bossexplo()
    {

        while (true)
        {
            int explonum = Random.Range(0, 4);
            float x = Random.Range(-2f, 2f),
                  y = Random.Range(-2f, 2f);
            Instantiate(bossexplode[explonum], transform.position + new Vector3(x, y), Quaternion.identity);
            yield return new WaitForSeconds(0.08f);
        }
       
        
        
    }

}
