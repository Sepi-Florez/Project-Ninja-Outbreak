using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    public CameraBounds cameraBounds;
    public CharacterMoveV3 characterMoveV3;
    public GameObject projectile;

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
        Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)) - spawnPos))).transform;
        Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * 40;
        yield return Projectile;
    }
}