using UnityEngine;
using System.Collections;
using System;

public class MainEnemy : EnemyVirtual {

    public bool attackMode;
    private bool canSpawnBullet;
    private bool canLook;
    public bool lookAroundCoroutine;
    public float distanceToPlayer;
    public float shootingDistance;
    public Vector3 lookAroundLoc;
    public GameObject bulletPrefab;

    void Start () {

        lookAroundLoc = transform.position;
        patrolPoint = patrolPointOne;
        lookAroundCoroutine = true;
        canSpawnBullet = true;
    }
	
	void Update () {

        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Movement();
        IsDetected();
        Attacking();
    }

    public override void Movement() {
        float moveSp = moveSpeed * Time.deltaTime;
        if (onPatrol == true) {
            if (toPatrol == true) {
                transform.LookAt(patrolPoint.transform.position);
                detected = false;
                transform.position = Vector3.MoveTowards(transform.position, patrolPoint.transform.position, moveSp);
                if (transform.position == patrolPoint.transform.position) {
                    StartCoroutine(WaitToMove());
                }
            } else {
                transform.position = Vector3.MoveTowards(transform.position, lookAroundLoc, moveSp);
                if (lookAroundCoroutine == true) {
                    StartCoroutine(LookAround());
                }
            }
        }
    }
    public void IsDetected() {
        if(detected == true) {
            attackMode = true;
            StopCoroutine(LookAround());
        } else {
            attackMode = false;
        }
    }

    public void Attacking() {
        float moveSp = moveSpeed * Time.deltaTime;
        if (shootingDistance >= distanceToPlayer) {
            attackMode = false;
            canLook = false;
            if(canSpawnBullet == true) {
                StartCoroutine(Shooting(1));
            }
        }
        if(attackMode == true) {
            transform.Translate(Vector3.forward * moveSp);
            if(canLook == true) {
                transform.LookAt(player.transform);
            }
        }
    }

    IEnumerator Shooting(float waitTime) {
        canSpawnBullet = false;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * 1, transform.rotation) as GameObject;
        yield return new WaitForSeconds(waitTime);
        canSpawnBullet = true;
    }
    IEnumerator WaitToMove() {
        if (patrolPoint == patrolPointOne) {
            yield return new WaitForSeconds(1);
            patrolPoint = patrolPointTwo;
        } else {
            yield return new WaitForSeconds(1);
            patrolPoint = patrolPointOne;
        }
    }
    IEnumerator LookAround() {
        lookAroundCoroutine = false;
        transform.Rotate(0, 180, 0);
        yield return new WaitForSeconds(3);
        if (detected == false) {
            StartCoroutine(LookAround());
        }
    }
}
