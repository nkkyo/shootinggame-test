using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endingfade : MonoBehaviour
{

    float gametime;
    Image fada;
    public Color startcolor;
    public Color endcolor;
    public float fadaintime;
    public float fadaouttime;
    float intime;
    float outtime;
    public bool secondon = false;
    public bool end = false;

    // Use this for initialization
    void Start()
    {

        fada = GetComponent<Image>();

        StartCoroutine("first");



    }

    // Update is called once per frame
    void Update()
    {
        gametime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) && !secondon && gametime >= 4)
        {
            secondon = true;
            StartCoroutine("second");
        }
    }

    IEnumerator first()
    {
        yield return new WaitForSeconds(1);
        while (fadaintime >= intime)
        {
            intime += Time.deltaTime;
            fada.color = new Color(1, 1, 212 / 255f, Mathf.Lerp(startcolor.a, endcolor.a, intime / fadaintime));
            yield return new WaitForSeconds(0);
        }

        yield break;

    }

    IEnumerator second()
    {


        while (fadaintime >= outtime)
        {

            outtime += Time.deltaTime;
            fada.color = new Color(1, 1, 212 / 255f, Mathf.Lerp(endcolor.a, startcolor.a, outtime / fadaouttime));
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(1);
        end = true;
       
        yield break;

    }


}