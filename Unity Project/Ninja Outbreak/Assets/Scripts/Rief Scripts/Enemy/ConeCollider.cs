using UnityEngine;
using System.Collections;

public class ConeCollider : MonoBehaviour {
    //NIET AANZITTEN.
    //Deze class moet op de Collider van het object van de Viewpoint (guard).
    public GameObject enemy;
	
	void OnTriggerStay (Collider player) {
           EnemyVirtual standardEnemy = enemy.transform.GetComponent<EnemyVirtual> ();
        if (player.tag == "Player") {
            standardEnemy.detected = true;
        }
	}
}
