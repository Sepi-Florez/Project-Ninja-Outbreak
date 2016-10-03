using UnityEngine;
[System.Serializable]
public class AttacksTypes
{
    public string name;
    public Animation animation;
    public GameObject bone; //which hitbox does damage, arm, leg sword
    public int damage;
}
public class Attack : MonoBehaviour
{
    public AttacksTypes[] attackTypes;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Pick Random Animation based on positie en vorige attack?? (in lucht = dropkick, rennend op grond = raiden style
        }
    }
}
