using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum Playerstate
    {
        Normal,
        Wide,
        laser
    }

  

    public Playerstate playerstate;

    sescript se;

    public Gemecon gamecon;
    public GameObject P_explo;
    new SpriteRenderer renderer;
    Animator animator;
    Rigidbody2D Rigid2D;
    float syokispeed = 5;
    public float speed;
    float axisx, axisy;
    float Shotspan = 0.1f, ShotCount;
    public GameObject N_obj;
    public GameObject W_obj;
    public GameObject L_obj;
    public float mutekitime;
    float mutekicheck;
    bool mutekibool;
   

    // Use this for initialization
    void Start()
    {

        gamecon = GameObject.FindWithTag("Respawn").GetComponent<Gemecon>();
        mutekibool = false;
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Rigid2D = GetComponent<Rigidbody2D>();
        playerstate = Playerstate.Normal;
        se = GameObject.FindWithTag("se").GetComponent<sescript>();
        speed = syokispeed;
    }

    // Update is called once per frame
    void Update()
    {
        axisx = Input.GetAxisRaw("Horizontal");
        axisy = Input.GetAxisRaw("Vertical");

        //gekiha中のメソッド
        if (gamecon.gamestate == global::Gemecon.Gamestate.gekiha)
        {
            gameObject.layer = LayerMask.NameToLayer("Playermuteki");
            Rigid2D.velocity = new Vector2(Rigid2D.velocity.x, 3);
        
        }

        //play中のメソッド
        if (gamecon.gamestate != global::Gemecon.Gamestate.gekiha)
        {
            ShotCount -= Time.deltaTime;
            mutekicheck -= Time.deltaTime;
            Animate();
            Seigen();

            if (Input.GetKey(KeyCode.Z) && playerstate != Playerstate.laser) Shot();
            if (Input.GetKeyDown(KeyCode.Z) && playerstate == Playerstate.laser)
                Instantiate(L_obj, transform.position + new Vector3(0, 0.07f), Quaternion.identity);
        }
        //intro中のメソッド
        if (gamecon.gamestate == global::Gemecon.Gamestate.intro && !mutekibool) {
            mutekibool = true;
            gameObject.layer = LayerMask.NameToLayer("Playermuteki");
            StartCoroutine("muteki");
        }
        
        if (mutekicheck <= 0) {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
       

    }

   

    IEnumerator muteki() {
        mutekicheck = mutekitime;
        while (true) {
            renderer.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.05f);
            renderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.05f);
            if (mutekicheck <= 0)
            {
                gamecon.gamestate = global::Gemecon.Gamestate.play;
                break;
            }
        }
    }

    void Seigen()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.1f));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 1));

        Vector2 pos = transform.position;
        
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }

    void Animate()
    {
        if (axisx == 1) animator.SetBool("right", true);
        else animator.SetBool("right", false);
        if (axisx == -1) animator.SetBool("left", true);
        else animator.SetBool("left", false);
    }

    private void FixedUpdate()
    {
        if (gamecon.gamestate == global::Gemecon.Gamestate.play||
            gamecon.gamestate == global::Gemecon.Gamestate.intro||
            gamecon.gamestate == Gemecon.Gamestate.clear)
        {

            if (axisx != 0 || axisy != 0)
                Rigid2D.velocity = new Vector2(speed * axisx, speed * axisy);

            if (axisx == 0 && axisy == 0)
                Rigid2D.velocity = new Vector2(0, 0);
        }
    }

    void Shot()
    {
        if (ShotCount <= 0)
        {

            switch (playerstate)
            {
                case Playerstate.Normal:
                    Instantiate(N_obj, transform.position + new Vector3(0.4f, 0),
                        Quaternion.identity);
                    Instantiate(N_obj, transform.position + new Vector3(-0.4f, 0),
                        Quaternion.identity);
                    se.source.PlayOneShot(se.playershot);
                    ShotCount = Shotspan;
                    break;

                case Playerstate.Wide:
                  
                    Instantiate(W_obj, transform.position, Quaternion.identity);
                    Instantiate(W_obj, transform.position, Quaternion.Euler(0,0, 22.5f));
                    Instantiate(W_obj, transform.position, Quaternion.Euler(0, 0, -22.5f));
                    Instantiate(W_obj, transform.position, Quaternion.Euler(0, 0, 45));
                    Instantiate(W_obj, transform.position, Quaternion.Euler(0, 0, -45));
                    ShotCount = Shotspan;
                    break;


                 default:break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gamecon.gamestate==global::Gemecon.Gamestate.play)
        {
            if (other.gameObject.tag == "Enemybullet" ||
                other.gameObject.tag == "enemy" ||
                other.gameObject.tag == "boss") {

                if (gamecon.gamestate != Gemecon.Gamestate.clear)
                {
                    Instantiate(P_explo, transform.position, Quaternion.identity);
                    se.source.PlayOneShot(se.explo);
                    gamecon.gamestate = global::Gemecon.Gamestate.gekiha;
                    Destroy(gameObject);
                }
            }
        }
        
        switch (other.gameObject.tag) {
            case "Item_W":Destroy(other.gameObject);
                playerstate = Playerstate.Wide;
                break;
            case "Item_L":
                Destroy(other.gameObject);
                playerstate = Playerstate.laser;
                break;
            default: break;
        }


    }

   
}
