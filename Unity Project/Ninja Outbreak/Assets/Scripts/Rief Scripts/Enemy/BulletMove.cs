using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public float bulletSpeed;
	void Start () {
	
	}
	
	void Update () {
        float moveSpeed = bulletSpeed * Time.deltaTime;
        transform.position += transform.forward * moveSpeed;
	}
    void OnCollisionEnter(Collision bullet) {
        if(bullet.transform.tag == "Player") {
            Destroy(this.gameObject);
        }
    }
}
