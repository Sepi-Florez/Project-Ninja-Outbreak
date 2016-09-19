using UnityEngine;
using System.Collections;

public abstract class EnemyVirtual : MonoBehaviour {

    public float moveSpeed;
    public bool onPatrol;
    public GameObject patrolPoint;
    public GameObject patrolPointOne;
    public GameObject patrolPointTwo;
    public GameObject detectObj;

    public abstract void Movement();

    public abstract void Detect();

}
