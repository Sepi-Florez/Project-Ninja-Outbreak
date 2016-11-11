using UnityEngine;
using System.Collections;

public class ConeCollider : MonoBehaviour {
    //NIET AANZITTEN.
    //Deze class moet op de Collider van het object van de Viewpoint (guard).
    public GameObject enemy;
    EnemyVirtual enemyDetection;
    public bool canSpawn;

    void Start() {
        enemyDetection = enemy.transform.GetComponent<EnemyVirtual>();
    }
	void OnTriggerEnter (Collider player) {
        if (player.tag == "Player") {
            if (enemy.transform.tag == "SamuraiEnemy") {
                enemyDetection.onPatrol = false;
                enemyDetection.detected = true;
            }
            if (enemy.transform.tag == "AlarmEnemy") {
                if (enemy.GetComponent<CameraEnemy> ().canSpawn == true) {
                    enemy.GetComponent<CameraEnemy> ().detected = true;
                }
            }
        }
	}
    void OnTriggerExit(Collider player) {
        if (player.tag == "Player") {
            if (enemy.transform.tag == "SamuraiEnemy") {
                enemyDetection.detected = false;
                enemyDetection.onPatrol = true;
                enemy.transform.GetComponent<MainEnemy>().lookAroundCoroutine = true;
            }
            if(enemy.transform.tag == "AlarmEnemy") {
                enemy.GetComponent<CameraEnemy> ().detected = false;
            }
        }
    }
}
