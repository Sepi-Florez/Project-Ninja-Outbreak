using UnityEngine;
using System.Collections;
using System;

public class SamuraiEnemy : EnemyVirtual {

    public bool standStill; //zet dit op true als je niet wilt dat ie patrolled.
    public bool justLooking; //Aanzetten als enemy alleen moet rondkijken.
    public bool attackMode;
    private int looked;
    public float distanceToPlayer;
    public float shootingDistance;

	void Start () {

	}
    void Update () {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Movement ();
        IsDetected ();
        Attacking();
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
            attackMode = true;
        }
    }
    public void Attacking() {
        if(attackMode == true) {
            transform.LookAt(player.transform.position);
            if (distanceToPlayer >= shootingDistance) {
                Vector3.MoveTowards (transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }
            else {
                Shooting ();
            }
        }
    }
    public void Shooting () {
        print ("time to shoot");
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
