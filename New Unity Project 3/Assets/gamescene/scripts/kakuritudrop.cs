using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kakuritudrop : MonoBehaviour {

    public bool L, W, P;
    GameObject LI, WI, PI;


    // Use this for initialization
    void Start()
    {
        LI = (GameObject)Resources.Load("Item_L");
        WI = (GameObject)Resources.Load("Item_W");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        int par = Random.Range(1, 101);
        if (par <= 3) if (L == true) Instantiate(LI, transform.position, Quaternion.identity);
        if (par > 3 && par < 7) if (W == true) Instantiate(WI, transform.position, Quaternion.identity);


        //if (P == true) Instantiate(LI, transform.position, Quaternion.identity);

    }
}
