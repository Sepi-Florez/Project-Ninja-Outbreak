using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    public CameraBounds cameraBounds;
    public GameObject projectile;
    public int shurikenSpeed = 40, ammo = 3;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= transform.position.x)
            StartCoroutine(SimulateProjectile());
        }
    }

    IEnumerator SimulateProjectile()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)) - spawnPos))).transform; //Input.mousePosition.z)) - spawnPos))).transform; //cameraBounds.zOffset)) - spawnPos))).transform;
        Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * shurikenSpeed;
        yield return Projectile;
    }
}