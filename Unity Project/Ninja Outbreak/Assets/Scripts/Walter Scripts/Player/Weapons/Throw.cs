using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    //public CameraBounds cameraBounds;
    public GameObject projectile;
    public Transform thing;
    public int shurikenSpeed = 40, ammo = 3;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(SimulateProjectile());
        }
    }

    IEnumerator SimulateProjectile()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.DrawLine(mousePos, spawnPos);
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

        Debug.DrawLine(transform.position, mouseposition);

        /*
        Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, Quaternion.LookRotation(mousePos - spawnPos))).transform;
        Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * shurikenSpeed;
        */
        yield return null;
    }
}