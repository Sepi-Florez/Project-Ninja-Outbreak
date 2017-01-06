using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut : MonoBehaviour {
    public string tutorialMessage;
    public float tutorialLife;
    void onTriggerEnter(Collision player) {
        if(player.transform.tag == "Player") {
            //player.transform.GetComponent<PlayerUI>().StartCoroutine(Tutorial(tutorialMessage, tutorialLife));
        }
    }
}
