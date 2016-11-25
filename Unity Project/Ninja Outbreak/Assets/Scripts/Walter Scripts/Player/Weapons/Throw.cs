using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Throw : MonoBehaviour
{
    //public CameraBounds cameraBounds;
    public GameObject projectile;
    public int shurikenSpeed = 20, reloadTime = 2, maxAmmo = 3, maxShurikensInLevel = 9;
    [Space(10)]
    //[HideInInspector]
    public int ammo = 3;
    [HideInInspector]
    public List<Transform> shurikenList = new List<Transform>();

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(SimulateProjectile());
        }
    }

    IEnumerator SimulateProjectile()
    {
        if (ammo >= 0)  //if(shurikenList.Count)
        {
            ammo--;
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            //Ray mouseRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 mousePos = mouseRay.origin;

            Debug.DrawLine(mousePos, transform.position, Color.black);
            Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, Quaternion.LookRotation(mousePos - spawnPos))).transform;
            Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * shurikenSpeed;
            shurikenList.Add(Projectile);

            if(shurikenList.Count-1 >= maxShurikensInLevel)
            {
                shurikenList.RemoveAt(0);
            }

            yield return null;
        }
        else if (ammo <= 1)
        {
            yield return new WaitForSeconds(reloadTime);
            ammo = maxAmmo;
        }

    }
}