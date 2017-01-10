using UnityEngine;
using System.Collections;

/*[System.Serializable]
public class Weapon
{
    public string xmlLoc;
    public Animation[] animations;
    void Start()
    {
        //animations[i].GetClip("name").length
        //Retrieve XML files en pleur ze in de animations enzo
    }
}*/

public class WeaponSystem : MonoBehaviour
{
    public Collider col;
    string curAnim;
    public Animation anim;
    int damage;

    static int atakState = Animator.StringToHash("Base.Atak1");
    //public Weapon weapon;
    //public float timerOld, timerNew;
    //public currentAttack ;

    void Start()
    {
        //atakState = GetComponent<Animator>();
        //timerOld = Time.time;
    }

    void Update()
    {
        //currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack(col));
        }
    }

    private IEnumerator Attack(Collider coll)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("FooBar"));
        float curAnimLenght = 1f; //anim.GetClip(curAnim).length;
        //anim.getcurrent

        foreach (Collider c in cols)
        {
            //c.GetComponent<Health>().health -= damage/curAnimLenght;
            Debug.Log(c.name);
            yield return c;
        }
        yield return new WaitForSeconds(curAnimLenght);
    }

    //IEnumerator Attack()
    //{
        //timerNew = Time.time;
        //timerOld - timerNew

       // return null;
    //}
}