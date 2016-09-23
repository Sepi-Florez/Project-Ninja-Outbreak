using UnityEngine;
using System.Collections;
using System;

public class SamuraiEnemy : EnemyVirtual {

    public bool standStill; //zet dit op true als je niet wilt dat ie patrolled.

	void Start () {
	
	}
    void Update () {
        Movement ();
    }
    public override void Movement () {
        float moveTo = moveSpeed * Time.deltaTime;
        if (onPatrol == true && standStill == false) {
            transform.LookAt (patrolPoint.transform.position);
            detected = false;
            transform.position = Vector3.MoveTowards (transform.position, patrolPoint.transform.position, moveTo);
            if (transform.position == patrolPoint.transform.position) {
                StartCoroutine (WaitToMove ());
            }
        }
        else if(standStill == true){
            StartCoroutine (LookAround ());
        }
    }
    IEnumerator WaitToMove () {
        if (patrolPoint == patrolPointOne) {
            yield return new WaitForSeconds (1);
            patrolPoint = patrolPointTwo;
        }
        else {
            yield return new WaitForSeconds (1);
            patrolPoint = patrolPointOne;
        }
    }
    IEnumerator LookAround () {
        standStill = false;
        transform.Rotate (0, 180, 0);
        yield return new WaitForSeconds (3);
        StartCoroutine (LookAround ());
    }
}
