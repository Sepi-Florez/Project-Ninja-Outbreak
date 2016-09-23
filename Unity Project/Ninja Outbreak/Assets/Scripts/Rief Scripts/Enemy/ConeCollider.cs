using UnityEngine;
using System.Collections;

public class ConeCollider : MonoBehaviour {

    public GameObject enemy;
	
	void OnTriggerStay (Collider player) {
        StandardEnemy standardEnemy = enemy.transform.GetComponent<StandardEnemy> ();
        if (player.tag == "Player") {
            standardEnemy.detected = true;
        }
	}
}
