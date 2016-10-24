using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

    public Transform shurikenSpawn;
    public GameObject shuriken;
    public int shurikendamage;
    void Start () {

    }
	//cooldown
	void Update () {

        if (Input.GetButtonDown("Fire2"))
        {
            var pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);

            var q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            var go = Instantiate(shuriken, shurikenSpawn.position, q);
            //go.rigidbody2D.AddForce(go.transform.up * 500.0);
        }
    }
}
