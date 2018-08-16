using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadascript : MonoBehaviour {

 
    Image fada;
    public Color startcolor;
    public Color endcolor;
    public float fadaintime;
    public float fadaouttime;
    public float syouhitime;
    float intime;
    float outtime;

    // Use this for initialization
    void Start()
    {
       
        fada = GetComponent<Image>();
        
        StartCoroutine("first");
        
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator first()
    {
        while (fadaintime >= intime)
        {
            intime += Time.deltaTime;
            fada.color = new Color(1, 1, 202 / 255f, Mathf.Lerp(startcolor.a, endcolor.a, intime / fadaintime));
            yield return new WaitForSeconds(0);
        }

        yield break;

    }

    IEnumerator second() {
        yield return new WaitForSeconds(2);

        while (fadaintime >= outtime)
        {

            outtime += Time.deltaTime;
            fada.color = new Color(1, 1, 202/255f, Mathf.Lerp(endcolor.a, startcolor.a, outtime / fadaouttime));
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ending");

        yield break;
    }
   

}
