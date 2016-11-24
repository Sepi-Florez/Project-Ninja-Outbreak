using UnityEngine;
using System.Collections;

public class ObjectFade : MonoBehaviour {
    public float fadeSpeed = 0.5f;
    [Range(0, 1)]
    public float fadeLimit = 0.1f;
    public LayerMask hideable;
    private Transform hidingObject;
    public GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        CheckIfCamObstructed();
       
    }

    private void CheckIfCamObstructed() {
        Vector3 dir = player.transform.position - transform.position;
        RaycastHit hit;
        print("Jannogeenspls");
        Debug.DrawRay(transform.position, dir, Color.red);
        if (Physics.Raycast(transform.position, dir, out hit, 100, hideable)) {
            FadingAlpha(hit.transform);
            
            print("Jnpls");
        }
        else if (hidingObject != null)
            ReturnFade();
    }

    private void FadingAlpha(Transform fadeable) {
        if (hidingObject != null && hidingObject != fadeable)
            ReturnFade();
        Color tempMat = fadeable.GetComponent<Renderer>().material.color;
        if (tempMat.a > fadeLimit) {
            tempMat.a -= fadeSpeed * Time.deltaTime;
        }
        fadeable.GetComponent<Renderer>().material.color = tempMat;
        hidingObject = fadeable;
    }

    private void ReturnFade() {
        Color tempMatHid = hidingObject.GetComponent<Renderer>().material.color;
        tempMatHid.a = 1f;
        hidingObject.GetComponent<Renderer>().material.color = tempMatHid;
    }
}