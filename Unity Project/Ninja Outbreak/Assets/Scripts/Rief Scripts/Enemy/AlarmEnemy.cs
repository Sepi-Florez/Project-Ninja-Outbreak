using UnityEngine;
using System.Collections;
using System;

public class AlarmEnemy : EnemyVirtual {

    public Transform alarmObj;
    private float waitTime = 0.5f;

	void Start () {
        patrolPoint = patrolPointOne;
    }
	

	void Update () {
        Movement ();
        Patrol ();
        AlarmTrigger ();
	}

    public override void Movement() {
        if(detected == true) {
            onPatrol = false;
            StartCoroutine(MoveToAlarm());
        }
    }

    public void Patrol() {
        float moveSp = moveSpeed * Time.deltaTime;
        if(onPatrol == true) {
            transform.LookAt(patrolPoint.transform.position);
            detected = false;
            transform.position = Vector3.MoveTowards (transform.position, patrolPoint.transform.position, moveSp);
            if(transform.position == patrolPoint.transform.position) {
                StartCoroutine (WaitToMove ());
            }
        }
    }

    public void AlarmTrigger() {
        if(alarmObj != null) {
            if(transform.position == alarmObj.transform.position) {
                StartCoroutine(TurnAlarmOn());
                Destroy(alarmObj.gameObject);
            }
        }
    }
    IEnumerator WaitToMove() {
        yield return new WaitForSeconds(1);
        if (patrolPoint == patrolPointOne) {
            patrolPoint = patrolPointTwo;
        } else {
            patrolPoint = patrolPointOne;
        }
    }
    IEnumerator MoveToAlarm() {
        float moveSp = moveSpeed * Time.deltaTime;
        yield return new WaitForSeconds(waitTime);
        if (alarmObj != null) {
            transform.LookAt(alarmObj);
            transform.position = Vector3.MoveTowards(transform.position, alarmObj.position, moveSp * 2);
        }
    }
    IEnumerator TurnAlarmOn() {
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<SpawnEnemies>().spawnOn = true;
        player.GetComponent<SpawnEnemies>().SpawnActive();
        StopCoroutine(TurnAlarmOn());
    }
}
