using UnityEngine;
using System.Collections;

public class CameraEnemy : MonoBehaviour {

    public GameObject player;
    public bool detected;
    public bool canSpawn;
	
    void Start () {
        canSpawn = true;
    }
	void Update () {
        Detection ();
	}
    void Detection () {
        if (detected == true) {
            StartCoroutine (SpawnEnemies ());
        }
    }
    IEnumerator SpawnEnemies () {
        detected = false;
        yield return new WaitForSeconds (1);
        player.GetComponent<SpawnEnemies> ().spawnOn = true;
        player.GetComponent<SpawnEnemies> ().SpawnActive ();
        canSpawn = false;
        StopCoroutine (SpawnEnemies ());
    }
}
