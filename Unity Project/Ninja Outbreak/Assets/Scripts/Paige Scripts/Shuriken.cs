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
            Vector3 sp = Camera.main.WorldToScreenPoint(shurikenSpawn.position);
            Vector3 dir = (Input.mousePosition - sp).normalized;
            shuriken.GetComponent<Rigidbody2D>().AddForce(dir * 400);

            //Instantiate(shuriken , shurikenSpawn.position, Quaternion.identity);
            
        }
    
    }
    void OnCollissionEnter()
    {
        //Destroy(shuriken);
    }
}
