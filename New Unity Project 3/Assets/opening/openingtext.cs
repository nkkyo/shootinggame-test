using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openingtext : MonoBehaviour {

    public GameObject a;
    openingfade fada;
    Text gametext;
   [TextArea(2,5)] public string[] text;
    public float[] motionspeed;
    public float[] nexttime;
    public float starttime;

	// Use this for initialization
	void Start () {
        fada = a.GetComponent<openingfade>();
        gametext = GetComponent<Text>();
        StartCoroutine("preview");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator preview() {
        yield return new WaitForSeconds(starttime);
        for (int i = 0; i < text.Length; i++) {
            int textcount=1;
            while (true) {
                gametext.text = text[i].Substring(0, textcount);
             
                textcount++;
                yield return new WaitForSeconds(motionspeed[i]);
                if (text[i].Length < textcount) break;
            }
            yield return new WaitForSeconds(nexttime[i]);
         }
        yield return new WaitForSeconds(1);
        if(!fada.secondon)fada.StartCoroutine("second");
    }
}
