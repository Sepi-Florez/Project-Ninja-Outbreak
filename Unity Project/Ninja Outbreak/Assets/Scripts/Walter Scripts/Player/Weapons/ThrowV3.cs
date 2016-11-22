using UnityEngine;
using System.Collections;

public class ThrowV3 : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 5.0f;
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y + 1);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90);
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody>().velocity = direction * speed;
        }*/
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Transform Projectile = ((GameObject)Instantiate(bullet, spawnPos, Quaternion.LookRotation(mousePos - spawnPos))).transform;
            Projectile.LookAt(mousePos);
            Projectile.GetComponent<Rigidbody>().velocity = Projectile.forward * speed * Time.deltaTime;

        }
    }
}
