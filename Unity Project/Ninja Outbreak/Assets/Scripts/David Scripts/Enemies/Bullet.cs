using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifeSpan;
    public float hitRange;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        StartCoroutine(Death());
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(transform.position, transform.forward, out hit, hitRange)) {
            if(hit.transform.tag == "Player") {
                //hit.transform.GetComponent<ScriptName>().Health();
            }

        }
	}
    IEnumerator Death() {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }
}   
