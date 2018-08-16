using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yajirusi : MonoBehaviour {

    int num = 0;
    RectTransform rect;
    AudioSource audios;
   

	// Use this for initialization
	void Start () {
        audios = GetComponent<AudioSource>();
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (num == 0 && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))) {
            num++;
            rect.localPosition = rect.localPosition + new Vector3(0, -200);
            audios.Play();
            return;
        }

        if (num == 1 && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            num--;
            rect.localPosition = rect.localPosition + new Vector3(0, 200);
            audios.Play();
            return;
        }
            if (Input.GetKeyDown(KeyCode.Z)) {
            if (num == 0) SceneManager.LoadScene("game");
            else SceneManager.LoadScene("option");
               
            
        }
	}
}
