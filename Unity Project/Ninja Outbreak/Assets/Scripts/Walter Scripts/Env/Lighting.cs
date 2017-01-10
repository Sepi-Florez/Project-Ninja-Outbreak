using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour
{
    [Space(10)]
    [Tooltip("Het Lichtje of de Material hier in flikkeren.")]
    public Object lichtje;
    [Space(5)]
    public Color color = Color.white;
    [Tooltip("Welke kleur kanalen gerandomized moeten worden (bv. rood voor die borden, dan lijkt het alsof het bord aan en uit gaat)")]
    public bool[] rGBRandom;
    [Header("Timer en Brightness.")]
    public float timerMin;
    public float timerMax, brightnessMin, brightnessMax;

    void Start(){StartCoroutine(vuileFlikker());}

    IEnumerator vuileFlikker()
    {
        if (lichtje != null)
        {
            if (lichtje.GetType() == typeof(Light))
            {
                Light l = (Light)lichtje;
                l.intensity = Random.Range(brightnessMin, brightnessMax);
                yield return new WaitForSeconds(Random.Range(timerMin, timerMax));
                StartCoroutine(vuileFlikker());
            }
            else if (lichtje.GetType() == typeof(Material))
            {
                Material m = (Material)lichtje;
                if (rGBRandom.Length >= 0)
                {
                    if(rGBRandom[0]) color.r = Random.Range(0f, 1f);
                    if(rGBRandom[1]) color.g = Random.Range(0f, 1f);
                    if(rGBRandom[2]) color.b = Random.Range(0f, 1f);
                }
                m.SetColor("_EmissionColor", color * Random.Range(brightnessMin, brightnessMax));
                yield return new WaitForSeconds(Random.Range(timerMin, timerMax));
                StartCoroutine(vuileFlikker());
            }
        }
        else{yield return null;}
    }
}