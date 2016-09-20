using UnityEngine;
using System.Collections;

public class StandardEnemy : EnemyVirtual {

    public bool detected;
    public Transform alarmObj;
    private float waitTime = 1f;

    public void Start () {
        patrolPoint = patrolPointOne;
    }

    public void Update () {
        Movement ();
    }

    public override void Movement () {
        float moveTo = moveSpeed * Time.deltaTime;
        if (detected == true) {
            onPatrol = false;
            StartCoroutine (WaitForAlarm ());
        }
        if (onPatrol == true) {
            transform.LookAt (patrolPoint.transform.position);
            detected = false;
            transform.position = Vector3.MoveTowards (transform.position, patrolPoint.transform.position, moveTo);
            if (transform.position == patrolPoint.transform.position) {
                if(patrolPoint == patrolPointOne) {
                    patrolPoint = patrolPointTwo;
                }
                else {
                    patrolPoint = patrolPointOne;
                }
            }
        }
    }
    IEnumerator WaitForAlarm () {
        float moveTo = moveSpeed * Time.deltaTime;
        yield return new WaitForSeconds (waitTime);
        transform.LookAt (alarmObj);
        transform.position = Vector3.MoveTowards (transform.position, alarmObj.position, moveTo * 2);

    }
}
