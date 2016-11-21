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
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _collider.isTrigger = false;
        }
    }
    void OnCollisionEnter(Collision collision)
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
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && hasHit == true)
        {
            Destroy(gameObject);
            if(throwscript.ammo <= 3)
            {
                throwscript.ammo++;
            }
        }
    }
}