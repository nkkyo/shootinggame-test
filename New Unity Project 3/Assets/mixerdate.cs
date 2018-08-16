using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixerdate : MonoBehaviour {

    [SerializeField] UnityEngine.Audio.AudioMixer mixer;

	// Use this for initialization
	void Start () {
        mixer.SetFloat("BGM", Mathf.Lerp(-80, -15, PlayerPrefs.GetInt("vol",3) * 20 / 100f));
        mixer.SetFloat("SE", Mathf.Lerp(-80, -5, PlayerPrefs.GetInt("se",3) * 20 / 100f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
