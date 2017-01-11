using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut : MonoBehaviour {
    public string tutorialMessage;
    public float tutorialLife;

    void OnTriggerEnter(Collider player) {
        if(player.transform.tag == "Player") {
            player.transform.GetComponent<PlayerUI>().RunTuts(tutorialMessage, tutorialLife);
            print("tutdetect");
            Destroy(gameObject);
        }
    }
}
