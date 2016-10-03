using UnityEngine;
class Explosion : MonoBehaviour
{
    [SerializeField]
    private float fadePerSecond;
    private bool f1;
    private void Update ()
    {
        var material = GetComponent<Renderer>().material;
        //var color = material.color;
        var color2 = material.GetColor("_Color");
        if (Input.GetButton("Jump")) { f1 = true; }
        if (f1 == true)
        {
            material.color = new Color(color2.r, color2.g, color2.b, color2.a - (fadePerSecond/20 * Time.deltaTime));
            if (transform.localScale.y <= 20)
            {
                transform.localScale += new Vector3(fadePerSecond, fadePerSecond, fadePerSecond) * Time.deltaTime;
            }
            else
            {
                Destroy(transform.gameObject);
            }
        }
    }
}