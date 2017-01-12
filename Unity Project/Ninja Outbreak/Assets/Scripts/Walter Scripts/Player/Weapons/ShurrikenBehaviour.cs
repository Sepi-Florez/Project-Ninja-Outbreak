using UnityEngine;
public class ShurrikenBehaviour : MonoBehaviour
{
    Collider col;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            col.isTrigger = true;
            if (anim != null)
            {
                anim.SetBool("HasHit", true);
            }
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}