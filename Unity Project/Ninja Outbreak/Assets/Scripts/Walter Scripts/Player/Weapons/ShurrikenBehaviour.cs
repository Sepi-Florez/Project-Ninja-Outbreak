using UnityEngine;
public class ShurrikenBehaviour : MonoBehaviour
{
    Throw throwscript;
    bool hasHit;
    Collider _collider;
    public float damage;
    public Animator animator;

    void Awake()
    {
        throwscript = GameObject.Find("Player").GetComponent<Throw>();
        _collider = GetComponent<Collider>();
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            _collider.isTrigger = true;
            hasHit = true;
            if (animator != null)
            {
                animator.SetBool("HasHit", hasHit);
            }
        }
        else
        {
            throwscript.shurikenList.Remove(transform);
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && hasHit == true)
        {
            Destroy(gameObject);
            if(throwscript.ammo <= throwscript.maxAmmo)
            {
                throwscript.ammo++;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            _collider.isTrigger = true;
            if (animator != null)
            {
                animator.SetBool("HasHit", hasHit);
            }
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void Update()
    {
        Physics.IgnoreLayerCollision(8, 9, true);
    }
}