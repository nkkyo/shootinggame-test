using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roll : MonoBehaviour {

    public GameObject a;
    endingfade endbool;
    RectTransform rect;
    bool b = false;

	// Use this for initialization
	void Start () {
        endbool = a.GetComponent<endingfade>();
        rect = GetComponent<RectTransform>();
	}
	//-515
	// Update is called once per frame
	void Update () {
        if (endbool.end&&!b) {
            Debug.Log(endbool);
            b = true;
            StartCoroutine("scroll");
            }
        }
    IEnumerator scroll() {
        while (true) {
            rect.transform.localPosition += new Vector3(0, 1, 0);
            if (rect.localPosition.y > 525) break;
            yield return new WaitForSeconds(0);
        }
        yield return new WaitForSeconds(4);
       SceneManager.LoadScene("opening");
    }

	
}
