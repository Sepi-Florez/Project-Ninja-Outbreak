using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    public int myCheckPoint;
    public GameObject gameManager;
    public bool boss;

    void Start() {
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().checkpoints.Add(transform);
        if (boss)
            gameManager.GetComponent<GameManager>().OnSceneLoad();
    }
    public void OnTriggerEnter(Collider player) {
        print("check");
        if(player.transform.tag == "Player") {
            gameManager.GetComponent<GameManager>().save.checkPoint = myCheckPoint;
            gameManager.GetComponent<GameManager>().SaveGame();
            print("saved game");
        }
    }
}
