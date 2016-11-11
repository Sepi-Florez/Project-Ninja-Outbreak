using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    public CameraBounds cameraBounds;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public GameObject projectile;
    /*
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }
    */
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(SimulateProjectile());
        }
    }

    IEnumerator SimulateProjectile()
    {
        //Transform Projectile = ((GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y+1f,transform.position.z), Quaternion.identity)).transform;
        //Transform Projectile = ((GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.FromToRotation(Vector3.up, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset) - transform.position).normalized))).transform;
        Vector3 relativePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)) - transform.position;
        Transform Projectile = ((GameObject)Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.LookRotation(relativePos))).transform;
        //Instantiate(projectile, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)), Quaternion.identity);
        //Projectile.AddForce(transform.forward * 10);
        Projectile.GetComponent<Rigidbody>().velocity = (-Projectile.up) * 10;
        //Projectile.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset) - Projectile.position).normalized * (50f * Time.deltaTime));
        //Projectile.GetComponent<Rigidbody>().AddForce(transform.up * 2 - transform.position * 20f * Time.deltaTime);
        /*
        // Short delay added before Projectile is thrown
        //yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)));

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraBounds.zOffset)) - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }*/
        yield return Projectile;
    }
}