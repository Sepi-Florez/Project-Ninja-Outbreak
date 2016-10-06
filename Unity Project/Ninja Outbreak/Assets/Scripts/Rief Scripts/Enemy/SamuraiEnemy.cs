using UnityEngine;
using System.Collections;
using System;

public class SamuraiEnemy : EnemyVirtual {

    public bool standStill; //zet dit op true als je niet wilt dat ie patrolled.
    public bool justLooking; //Aanzetten als enemy alleen moet rondkijken.
    public int looked;

	void Start () {
	
	}
    void Update () {
        Movement ();
        IsDetected ();
    }
    public override void Movement () {
        float moveTo = moveSpeed * Time.deltaTime;
        if (onPatrol == true && standStill == false) {
            transform.LookAt (patrolPoint.transform.position);
            detected = false;
            transform.position = Vector3.MoveTowards (transform.position, patrolPoint.transform.position, moveTo);
            if (transform.position == patrolPoint.transform.position) {
                StartCoroutine (LookAround ());
            }
        }
        else if(standStill == true){
            StartCoroutine (LookAround ());
        }
    }
    public void IsDetected () {
        if (detected == true) {
            StopAllCoroutines ();
            transform.LookAt (player.transform.position);
            transform.position = Vector3.MoveTowards (transform.position, player.transform.position, moveSpeed * Time.deltaTime);
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
        yield return new WaitForSeconds (3);
        transform.Rotate (0, 180, 0);
        looked++;
        if (looked == 3 && justLooking == true) {
            StopCoroutine (LookAround ());
            StartCoroutine (WaitToMove ());
        }
        else {
            StartCoroutine (LookAround ());
        }
    }
}
