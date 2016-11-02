using UnityEngine;
using System.Collections;

public class ConeCollider : MonoBehaviour {
    //NIET AANZITTEN.
    //Deze class moet op de Collider van het object van de Viewpoint (guard).
    public GameObject enemy;
	
	void OnTriggerEnter (Collider player) {
           EnemyVirtual enemyDetection = enemy.transform.GetComponent<EnemyVirtual> ();
        if (player.tag == "Player") {
            enemyDetection.detected = true;
        }
	}
    void OnTriggerExit(Collider player) {
        EnemyVirtual enemyDetection = enemy.transform.GetComponent<EnemyVirtual>();
        SamuraiEnemy samuraiEnemy = enemy.transform.GetComponent<SamuraiEnemy>();
        if (player.tag == "Player") {
            enemyDetection.detected = false;
            samuraiEnemy.standStill = true;
            samuraiEnemy.looked = 0;
        }
    }
}
