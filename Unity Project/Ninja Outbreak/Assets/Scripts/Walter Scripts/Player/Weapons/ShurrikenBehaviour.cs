using UnityEngine;
public class ShurrikenBehaviour : MonoBehaviour
{
    bool hasHit;
    Collider _collider;
    void Awake()
    {
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
        }
    }
}