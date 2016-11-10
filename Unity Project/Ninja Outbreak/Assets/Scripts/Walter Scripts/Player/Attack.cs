using UnityEngine;
[System.Serializable]
public class AttacksTypes
{
    public string name;
    public Animation[] animations;
    public Collider[] colliders; //which hitbox does damage, arm, leg sword
    public float damage;
}
[RequireComponent(typeof(CharacterMoveV3))]
public class Attack : MonoBehaviour
{
    public CharacterMoveV3 movementScript;
    public AttacksTypes[] attackTypes;
    private AttacksTypes currentAttack;
    public int walkingMin, walkingMax, runningMin, runningMax, inAirMin, inAirMax;
    //[Header("Animation numbers")]
    void Update()
    {
        //Pick Random Animation based on positie en vorige attack?? (in lucht = dropkick, rennend op grond = raiden style
        if (movementScript.isClimbing == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (movementScript.controller.isGrounded)
                {
                    if (movementScript.speed >= 8)
                    {
                        currentAttack = attackTypes[Random.Range(runningMin, runningMax)];
                    }
                    else
                    {
                        currentAttack = attackTypes[Random.Range(walkingMin, walkingMax)];
                    }
                }
                else
                {
                    currentAttack = attackTypes[Random.Range(inAirMin, inAirMax)];
                }
            }
        }
    }
}
