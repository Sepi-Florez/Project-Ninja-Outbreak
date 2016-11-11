using UnityEngine;
using System.Collections;

public class ANGLETEST : MonoBehaviour
{
    public Transform target;
	void Update ()
    {
        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
       Debug.DrawRay(transform.position, transform.forward * 2, Color.white);
    }
}
