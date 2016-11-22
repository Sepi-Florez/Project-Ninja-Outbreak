using UnityEngine;
using System.Collections;

public class ThrowV2 : MonoBehaviour
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
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot2 = Quaternion.Euler(0f, rot_z - 90, 0f);


        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);

        //rotation.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-dir.x, -dir.z) * Mathf.Rad2Deg);
        //Quaternion rotation = Quaternion.identity;

        Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, rot2)).transform;
        Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * shurikenSpeed;
        yield return null;
    }
}
//Credit: https://goo.gl/vdkk7p