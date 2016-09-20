using UnityEngine;
using System.Collections;

public abstract class EnemyVirtual : MonoBehaviour {

    public float moveSpeed;
    public bool onPatrol;
    public GameObject patrolPoint;
    public GameObject patrolPointOne;
    public GameObject patrolPointTwo;

    public abstract void Movement();

}
