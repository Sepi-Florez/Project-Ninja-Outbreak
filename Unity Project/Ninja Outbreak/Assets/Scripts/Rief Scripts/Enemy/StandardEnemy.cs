using UnityEngine;
using System.Collections;

public class StandardEnemy : EnemyVirtual {

    public bool detected;
    public Transform alarmObj;

    public void Start () {
        patrolPoint = patrolPointOne;
    }

    public void Update () {
        Movement ();
    }

    public override void Movement () {
        float moveTo = moveSpeed * Time.deltaTime;
        if (detected == true) {
            transform.position = Vector3.MoveTowards (transform.position, alarmObj.position, moveTo * 2);
        }
        if (onPatrol == true) {
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
    public override void Detect () {
    }

}
