using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningpoint : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera") 
        StartCoroutine("keikoku");
    }

    IEnumerator keikoku() {


        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        text.gameObject.SetActive(false);
        yield break;

    }

}
