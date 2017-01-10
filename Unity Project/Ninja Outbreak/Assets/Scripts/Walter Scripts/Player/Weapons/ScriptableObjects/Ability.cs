using UnityEngine;
using System.Collections;

public abstract class Ability : ScriptableObject
{
    public string aName = "New Weapon";
    public Sprite sprite;
    public AudioClip sound;
    public float CoolDownTime =.5f;

    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}