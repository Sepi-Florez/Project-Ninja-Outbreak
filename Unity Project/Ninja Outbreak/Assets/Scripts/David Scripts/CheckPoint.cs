using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    public int myCheckPoint;
    public GameObject gameManager;
    void Start () {
        gameManager = GameObject.Find("GameManager");
    }
    public void OnTriggerEnter(Collider player) {
        print("check");
        if(player.transform.tag == "Player") {
            print("PlayerCheck");
            gameManager.GetComponent<GameManager>().save.checkPoint = myCheckPoint;
            gameManager.GetComponent<GameManager>().SaveGame();
        }
    }
}
