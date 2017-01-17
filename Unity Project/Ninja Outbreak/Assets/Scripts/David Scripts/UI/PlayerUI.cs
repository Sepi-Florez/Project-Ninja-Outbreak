using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    public GameObject tutorialCanvasObject;
    GameObject tutorialBalloon;
    GameObject tutorialText;

    public GameObject HealthCanvasObject;
    GameObject health1;
    GameObject health2;

	void Start () {
        tutorialCanvasObject = GameObject.FindGameObjectWithTag("TutorialObject");
        HealthCanvasObject = GameObject.FindGameObjectWithTag("HealthObject");
        tutorialBalloon = tutorialCanvasObject.transform.FindChild("TutBalloon").gameObject;
        tutorialText = tutorialCanvasObject.transform.FindChild("TutText").gameObject;
        health1 = HealthCanvasObject.transform.GetChild(0).gameObject;
        health2 = HealthCanvasObject.transform.GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {

	}
    public void RunTuts(string message, float alive) {
        StartCoroutine(Tutorial(message, alive));
        print("RunCoRoutine");
    }
    public IEnumerator Tutorial (string message,float alive) {
        tutorialCanvasObject.GetComponent<Animator>().SetBool("On", true);
        tutorialText.GetComponent<Text>().text = message;
        yield return new WaitForSeconds(alive);
        tutorialCanvasObject.GetComponent<Animator>().SetBool("On", false);

    }
    public void  Health() {
        if(HealthCanvasObject.transform.childCount > 0)
          Destroy(HealthCanvasObject.transform.GetChild(0).gameObject);
    }
}
