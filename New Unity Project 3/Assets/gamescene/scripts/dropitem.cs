using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropitem : MonoBehaviour {

    public bool L, W, P;
    GameObject LI, WI, PI;


	// Use this for initialization
	void Start () {
        LI = (GameObject)Resources.Load("Item_L");
        WI = (GameObject)Resources.Load("Item_W");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        if (L == true) Instantiate(LI, transform.position, Quaternion.identity);
        if (W == true) Instantiate(LI, transform.position, Quaternion.identity);
        if (P == true) Instantiate(LI, transform.position, Quaternion.identity);

    }
}
