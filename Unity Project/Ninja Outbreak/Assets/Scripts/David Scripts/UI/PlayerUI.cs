using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    GameObject tutorialBalloon;
    GameObject tutorialText;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator Tutorial (string message,float alive) {
        tutorialBalloon.SetActive(true);
        tutorialText.SetActive(true);
        tutorialText.GetComponent<Text>().text = message;
        yield return new WaitForSeconds(alive);
        tutorialBalloon.SetActive(false);
        tutorialText.SetActive(false);

    }
}
