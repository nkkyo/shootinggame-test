using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int zanki;
    int score;
    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "         X" + zanki.ToString("00") + "                          SCORE " + score.ToString("0000000000");
	}

    public void keisan(int tensuu)
    {
        score += tensuu;

    }

}
