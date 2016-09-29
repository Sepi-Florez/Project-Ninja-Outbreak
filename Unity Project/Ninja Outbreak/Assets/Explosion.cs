using UnityEngine;
class Explosion : MonoBehaviour
{
    [SerializeField]
    private float fadePerSecond;
    private void Update ()
    {
        var material = GetComponent<Renderer>().material;
        //var color = material.color;
        var color2 = material.GetColor("_Color");

        material.color = new Color(color2.r, color2.g, color2.b, color2.a - (fadePerSecond * Time.deltaTime));
        if (transform.localScale.y <= 20)
        {
            transform.localScale += new Vector3(fadePerSecond, fadePerSecond, fadePerSecond) * Time.deltaTime;
        }
        else
        {
            //Destroy(transform.gameObject);
        }
    }
}