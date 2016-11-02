using UnityEngine;
using System.Collections;
using System;

public class SamuraiEnemy : EnemyVirtual {

    public bool standStill; //zet dit op true als je niet wilt dat ie patrolled.
    public int maxLooks;
    public bool attackMode;
    public int looked;
    public float distanceToPlayer;
    public float shootingDistance;
    public GameObject bulletPrefab;
    private bool canSpawnBullet;

	void Start () {
        canSpawnBullet = true;
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
        } else {
            attackMode = false;
        }
    }
    public void Attacking() {
        if (shootingDistance >= distanceToPlayer) {
            attackMode = false;
            if (canSpawnBullet == true) {
                StartCoroutine(Shooting(1));
            }
        }
        if (attackMode == true) {
            transform.Translate(Vector3.forward * Time.deltaTime);
            transform.LookAt(player.transform);
        }
    }
    IEnumerator Shooting (float waitTime) {
        canSpawnBullet = false;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * 1, transform.rotation) as GameObject;
        yield return new WaitForSeconds(waitTime);
        canSpawnBullet = true;
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
        if (looked == maxLooks) {
            StopCoroutine (LookAround ());
            StartCoroutine (WaitToMove ());
        }
        else {
            StartCoroutine (LookAround ());
        }
    }
}
