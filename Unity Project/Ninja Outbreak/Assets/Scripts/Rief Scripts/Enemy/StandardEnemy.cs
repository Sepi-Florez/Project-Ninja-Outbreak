using UnityEngine;
using System.Collections;

public class StandardEnemy : EnemyVirtual {
    //moet op de AlertGuard.
    public bool detected; //laten zoals het is.
    public Transform alarmObj; //het alarm waar de enemy naartoe moet lopen.
    private float waitTime = 0.5f; //aanpassen als je de waittime niet genoeg vind nadat je detected bent.
    public GameObject player; //main character.

    public void Start () {
        patrolPoint = patrolPointOne;
    }

    public void Update () {
        Movement ();
        Patrol ();
        AlarmTrigger ();
    }

    public override void Movement () {
        if (detected == true) {
            onPatrol = false;
            StartCoroutine (WaitForAlarm ());
        }
    }
        public void Patrol () {
        float moveTo = moveSpeed * Time.deltaTime;
        if (onPatrol == true) {
            transform.LookAt (patrolPoint.transform.position);
            detected = false;
            transform.position = Vector3.MoveTowards (transform.position, patrolPoint.transform.position, moveTo);
            if (transform.position == patrolPoint.transform.position) {
                if (patrolPoint == patrolPointOne) {
                    patrolPoint = patrolPointTwo;
                }
                else {
                    patrolPoint = patrolPointOne;
                }
            }
        }
    }
    public void AlarmTrigger () {
        if (alarmObj != null) {
            if (transform.position == alarmObj.transform.position) {
                StartCoroutine (AlarmOn ());
                Destroy (alarmObj.gameObject);
            }
        }
    }
    IEnumerator WaitForAlarm () {
        float moveTo = moveSpeed * Time.deltaTime;
        yield return new WaitForSeconds (waitTime);
        if (alarmObj != null) {
            transform.LookAt (alarmObj);
            transform.position = Vector3.MoveTowards (transform.position, alarmObj.position, moveTo * 2);
        }
    }
    IEnumerator AlarmOn () {
        yield return new WaitForSeconds (waitTime);
        player.GetComponent<SpawnEnemies> ().spawnOn = true;
        player.GetComponent<SpawnEnemies> ().SpawnActive ();
        StopCoroutine (AlarmOn ());
    }
}