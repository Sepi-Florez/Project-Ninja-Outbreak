using UnityEngine;
[System.Serializable]
public class AttacksTypes
{
    public string name;
    public Animation[] animations;
    public Collider[] colliders; //which hitbox does damage, arm, leg sword
    public float damage;
}
public class Attack : MonoBehaviour
{
    public AttacksTypes[] attackTypes;
    public 

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Pick Random Animation based on positie en vorige attack?? (in lucht = dropkick, rennend op grond = raiden style
        }
    }
}
