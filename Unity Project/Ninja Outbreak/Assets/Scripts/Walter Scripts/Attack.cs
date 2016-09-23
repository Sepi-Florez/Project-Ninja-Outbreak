using UnityEngine;
public class Attack : MonoBehaviour
{
    public float rate;
    private float hitAgain = 0.0F;
    private bool h, v;
    public string currSwordPos, oldSwordPos;
    public enum SliceAnim{_1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12}
    public SliceAnim sliceAnim;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > hitAgain)
        {
            oldSwordPos = currSwordPos;
            hitAgain = Time.time + rate;
            int slice = Random.Range(0, 2);
            if (slice == 0)
            {
                h = !h;
            }
            if(slice == 1)
            {
                h = !h;
                v = !v;
            }
            if(slice == 2)
            {
                v = !v;
            }
            currSwordPos = v.ToString() + "_" + h.ToString();
        }
    }
}