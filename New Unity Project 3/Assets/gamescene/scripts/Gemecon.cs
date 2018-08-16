using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gemecon : MonoBehaviour {

    public enum Gamestate
    {
        intro,
        play,
        gekiha,
        clear,
    }
    public Gamestate gamestate;

   

    public Text gamestart;
    public Text gameover;
    public GameObject player;
    public Score score;
    public bool check;

    // Use this for initialization
    void Start () {
        gamestate = Gamestate.intro;
        check = false;
        StartCoroutine("first");
        Instantiate(player, Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.2f)), Quaternion.identity);
        Instantiate(Resources.Load("Item_W"), Camera.main.ViewportToWorldPoint(new Vector2(0.2f, 0.7f))+new Vector3(0,0,10), Quaternion.identity);
        Instantiate(Resources.Load("Item_L"), Camera.main.ViewportToWorldPoint(new Vector2(0.8f, 0.7f)) + new Vector3(0, 0, 10), Quaternion.identity);

    }

    // Update is called once per frame
    void Update () {
        if (gamestate == Gamestate.gekiha && !check)
        {
            StartCoroutine("resporn");
            check = true;
            
        }
	}

    IEnumerator resporn() {
        Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0));
        yield return new WaitForSeconds(1);
        if(score.zanki >=1) score.zanki--;
        if (score.zanki <= 0)
        {
            yield return new WaitForSeconds(1.3f);
            gameover.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("opening");
        }
        else
        {
            
            Instantiate(player, pos, Quaternion.identity);
            yield return new WaitForSeconds(1);
            gamestate = Gamestate.intro;
            check = false;
        }
       
        
    }

    IEnumerator first()
    {
        gamestart.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        gamestart.gameObject.SetActive(false);
    }
}
