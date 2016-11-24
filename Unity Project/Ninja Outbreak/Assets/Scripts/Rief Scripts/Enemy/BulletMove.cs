using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float bulletSpeed;
	
	void Update () {
        float moveSpeed = bulletSpeed * Time.deltaTime;
        transform.position += transform.forward * moveSpeed;
	}
    void OnCollisionEnter(Collision bullet) {
        if(bullet.transform.tag == "PlayerHit") {
            Destroy(this.gameObject);
        }
    }
}
