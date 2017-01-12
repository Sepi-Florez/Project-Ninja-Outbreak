using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Throw : MonoBehaviour
{
    //public CameraBounds cameraBounds;
    public Image darkMask;
    public GameObject projectile;
    public float maxAmmo,shurikenSpeed = 20,throwWait = .25f, reloadTime = 2, maxShurikens = 9;
    [HideInInspector]
    public float ammo = 4;
    [HideInInspector]
    public List<Transform> shurikenList = new List<Transform>();
    void Awake()
    {
        ammo = maxAmmo;
        StartCoroutine(SimulateProjectile());
    }

    /*void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(SimulateProjectile());
        }
    }*/

    IEnumerator SimulateProjectile()
    {
        if (Input.GetButton("Fire2"))
        {
            if (ammo - 1 >= 0)//if (ammo >= 0)  //if(shurikenList.Count)
            {
                ammo--;
                float startTime = Time.time;
                while (Time.time < startTime + throwWait)
                {
                    darkMask.fillAmount = Mathf.Lerp(darkMask.fillAmount, (ammo / maxAmmo), (Time.time - startTime) / throwWait);
                    yield return null;
                }

                //print("ammo = " + ammo + " maxAmmo = " + maxAmmo + " ammo/maxAmmo = " + (ammo / maxAmmo));
                Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

                //Ray mouseRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
                //Vector3 mousePos = mouseRay.origin;

                Debug.DrawLine(mousePos, spawnPos, Color.black);
                Transform Projectile = ((GameObject)Instantiate(projectile, spawnPos, Quaternion.LookRotation(mousePos - spawnPos))).transform;
                Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * shurikenSpeed;
                shurikenList.Add(Projectile);

                if (shurikenList.Count - 1 >= maxShurikens)
                {
                    shurikenList.RemoveAt(0);
                }
            }
            yield return new WaitForSeconds(throwWait);
        }

        if (ammo-1 < 0)
        {
            float startTime = Time.time;
            while (Time.time < startTime + reloadTime)
            {
                darkMask.fillAmount = Mathf.Lerp(darkMask.fillAmount, maxAmmo, (Time.time - startTime) / reloadTime);
                ammo = maxAmmo;
                print("ammo refilled");
                yield return null;
            }
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(SimulateProjectile());
    }
}