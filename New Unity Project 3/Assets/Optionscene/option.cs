using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Audio.AudioMixer mixer;

    int vol_num;
    int se_num;

   

    int num = 0;
    public Text vol;
    public Text se;
    RectTransform volposi;
    RectTransform seposi;
    RectTransform myposi;
    Vector3 startvol;
    Vector3 startse;


    public RectTransform[] posi;


    // Use this for initialization
    void Start()
    {
        vol_num = PlayerPrefs.GetInt("vol", 3);
        se_num = PlayerPrefs.GetInt("se", 3);

       
        myposi = GetComponent<RectTransform>();
        volposi = vol.GetComponent<RectTransform>();
        seposi = se.GetComponent<RectTransform>();
        startvol = volposi.localPosition;
        startse = seposi.localPosition;

        volposi.localPosition = volposi.localPosition + new Vector3((PlayerPrefs.GetInt("vol", 1)-3) * 110, 0, 0);
        seposi.localPosition = seposi.localPosition + new Vector3(( PlayerPrefs.GetInt("se", 1)-3) * 110, 0, 0);
     //   StartCoroutine("deb");
    }

    // Update is called once per frame
    void Update()
    {
       
        idou();
        tyousei();
    }

    IEnumerator deb() {
        while (true) {
            Debug.Log("se "+se_num+"  "+ "vol " + vol_num);
            Debug.Log(startse+"\n"+startvol);
            
            yield return new WaitForSeconds(3);
        }
    }

    void idou() {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (num != 2) num++;
            else num = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (num != 0) num--;
            else num = 2;
        }

        switch (num)
        {
            case 0:
                myposi.localPosition = posi[0].localPosition;
                break;
            case 1:
                myposi.localPosition = posi[1].localPosition;
                break;
            case 2:
                myposi.localPosition = posi[2].localPosition;
                break;
        }

        if (num == 2 && Input.GetKeyDown(KeyCode.Z)) SceneManager.LoadScene("startveiw");
        
    }

    void tyousei()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (num)
            {
                case 0:
                    if (vol_num != 0)
                    {
                        vol_num--;
                        PlayerPrefs.SetInt("vol", vol_num);
                        mixer.SetFloat("BGM", Mathf.Lerp(-80, 0, vol_num * 20 / 100f));
                        volposi.localPosition = startvol + new Vector3((PlayerPrefs.GetInt("vol", 1) - 3) * 110, 0, 0);
                    }
                    break;
                case 1:
                    if (se_num != 0)
                    {
                        se_num--;
                        PlayerPrefs.SetInt("se", se_num);
                        mixer.SetFloat("SE", Mathf.Lerp(-80, 0, se_num * 20 / 100f));
                        seposi.localPosition = startse + new Vector3((PlayerPrefs.GetInt("se", 1) - 3) * 110, 0, 0);
                    }
                    break;
                default: break;
            }
        }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                switch (num)
                {
                    case 0:
                        if (vol_num != 5)
                        {
                            vol_num++;
                        PlayerPrefs.SetInt("vol", vol_num);
                        mixer.SetFloat("BGM", Mathf.Lerp(-80, 0, vol_num * 20 / 100f));
                        volposi.localPosition = startvol + new Vector3((PlayerPrefs.GetInt("vol", 1) - 3) * 110, 0, 0);
                    }
                        break;
                    case 1:
                        if (se_num != 5)
                        {
                            se_num++;
                        PlayerPrefs.SetInt("se", se_num);
                        mixer.SetFloat("SE", Mathf.Lerp(-80, 0, se_num * 20 / 100f));
                        seposi.localPosition = startse + new Vector3((PlayerPrefs.GetInt("se", 1) - 3) * 110, 0, 0);
                    }
                        break;
                    default: break;
                }

            }
    }







}
