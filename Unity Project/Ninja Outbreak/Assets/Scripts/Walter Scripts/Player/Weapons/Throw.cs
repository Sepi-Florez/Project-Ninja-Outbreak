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
            StartCoroutine(SimulateProjectile());
        }
    }

    IEnumerator SimulateProjectile()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        Debug.DrawLine(spawnPos, mousePos);

        Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, Quaternion.LookRotation(mousePos - spawnPos))).transform;
        Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * shurikenSpeed;
        yield return null;
    }
}