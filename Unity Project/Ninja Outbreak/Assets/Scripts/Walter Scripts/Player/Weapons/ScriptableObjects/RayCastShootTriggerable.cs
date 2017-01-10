using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootTriggerable : MonoBehaviour
{
    [HideInInspector] public int gunDamage = 1;
    [HideInInspector] public float weaponRange = 50f;
    [HideInInspector] public float hitForce = 100f;
    [HideInInspector] public LineRenderer laserLine;
    public Transform gunEnd;

    public Camera cam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    public void Trigger()
    {
        laserLine = GetComponent<LineRenderer>();

        //cam = GetComponentInParent<Camera>();
    }

    public void Fire()
    {
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

        Debug.DrawRay(rayOrigin, cam.transform.forward * weaponRange, Color.red);

        RaycastHit hit;

        StartCoroutine(ShotEffect());

        laserLine.SetPosition(0, gunEnd.position);

        if(Physics.Raycast(rayOrigin, cam.transform.forward, out hit, weaponRange))
        {
            laserLine.SetPosition(1, hit.point);

            ShootableBox health = hit.collider.GetComponent<ShootableBox>();

            if ( health != null)
            {
                health.Damage(gunDamage);
            }

            if(hit.rigidbody != null)
            {
                health.Damage(gunDamage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
        }
        else
        {
            laserLine.SetPosition(1, cam.transform.forward * weaponRange);
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        //wait
        yield return shotDuration;

        laserLine.enabled = false;
    }
} 
