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
        GetComponent<Rigidbody>().isKinematic = true;
        _collider.isTrigger = true;
        hasHit = true;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && hasHit == true)
        {
            Destroy(gameObject);
        }
    }
}