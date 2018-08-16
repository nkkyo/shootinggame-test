using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamestarttext : MonoBehaviour {

    Outline outline;
    Text text;
    public Color startcolor;
    public Color endcolor;
    public float fadaintime;
    public float fadaouttime;
    public float syouhitime;
    float intime;
    float outtime;

	// Use this for initialization
	void Start () {
        outline = GetComponent<Outline>();
        text = GetComponent<Text>();
        StartCoroutine("first");
        StartCoroutine("second");

	}
	
	// Update is called once per frame
	void Update () {
    
    }

    IEnumerator first()
    {
        while (fadaintime >= intime)
        {
            intime += Time.deltaTime;
            text.color = new Color(1, 1, 158 / 255f, Mathf.Lerp(startcolor.a, endcolor.a, intime / fadaintime));
            outline.effectColor = new Color(0, 0, 0, Mathf.Lerp(0, 128 / 255f, intime / fadaintime));
             yield return new WaitForSeconds(0);
        }

        yield break;
       
    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(3);
        while (fadaintime >= outtime)
        {
            outtime += Time.deltaTime;
            text.color = new Color(1, 1, 158 / 255f, Mathf.Lerp(endcolor.a, startcolor.a, outtime / fadaouttime));
            outline.effectColor = new Color(0, 0, 0, Mathf.Lerp(128 / 255f,0, outtime / fadaouttime));
            yield return new WaitForSeconds(0);
        }

        yield break;

    }
    

}
