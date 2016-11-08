using UnityEngine;
using System.Collections;

public abstract class EnemyVirtual : MonoBehaviour {
    //NIET AANZITTEN.
    //hoeft nergens op.

    public GameObject player;
    public GameObject patrolPoint;
    public GameObject patrolPointOne;
    public GameObject patrolPointTwo;
    public float moveSpeed;
    public bool onPatrol;
    public bool toPatrol;
    public bool detected;

    public abstract void Movement();

}
