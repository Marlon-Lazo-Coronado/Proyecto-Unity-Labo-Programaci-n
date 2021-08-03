using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyEvent : UnityEngine.Events.UnityEvent 
{ 

}

[System.Serializable]
public class MyStringEvent : UnityEngine.Events.UnityEvent<string>
{

}


//Nuevo
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
//

public class Fighter : MonoBehaviour
{
    [SerializeField]
    int _lifes = 3;
    protected int lifes
    {
        get { return _lifes;}

        set
        {
            _lifes = value;
            whenLifesChange.Invoke(_lifes.ToString());
        }
    }
    [SerializeField]
    int _stamina = 3;

    protected int stamina
    {
        get { return _stamina;}

        set
        {
            _stamina = value;
            whenStaminaChange.Invoke(_stamina.ToString());
        }
    }


    [SerializeField]
    protected MyEvent whenDie;
    [SerializeField]
    protected MyStringEvent whenStaminaChange;
    [SerializeField]
    protected MyStringEvent whenLifesChange;
    [SerializeField]
    protected float horizontalSpeed;
    [SerializeField]
    protected Transform leftPunch;
    [SerializeField]
    protected Transform rightPunch;
    [SerializeField]
    protected float punchRadius = 0.1f;


    //public Animator animator2; //Nuevo//Nuevo//Nuevo//Nuevo//Nuevo


    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator anim;

    protected bool isGuard = false;
    //Nuevo

    protected virtual void OnDrawGizmosSelected()
    {
        if (leftPunch == null || rightPunch == null)
            return;
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(leftPunch.position, punchRadius);
        Gizmos.DrawWireSphere(rightPunch.position, punchRadius);
    }

    protected Rigidbody2D rb2D; //Viene de Alucard_Grav

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //Viene de Alucard_Grav
        //***********************
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //*****************************

        whenStaminaChange.Invoke(_stamina.ToString());
        whenLifesChange.Invoke(_lifes.ToString());
    }

    void GetPunch()
    {
        if (isGuard)
        {
            stamina -= 10;
            anim.SetTrigger("GetPunch");
            if (stamina == 0)          //Mio     
                whenDie.Invoke();     //Mio*
            return;
        }

        //animator2.SetBool("GetPunch", true);
        anim.SetTrigger("GetPunch");
        print("Golpeado!");
        lifes--;

        if (lifes <= 0)
            whenDie.Invoke();

    }

    public void AutoDestroy()
    {
        Destroy(gameObject);
    }



    protected IEnumerator Punch()
    {

        anim.SetTrigger("SendPunch");
        yield return new WaitForSeconds(0.8f);
            Vector2 punchPosition = sr.flipX ? leftPunch.position : rightPunch.position;
            var ob = Physics2D.CircleCast(punchPosition, punchRadius, Vector2.up);
            if (ob.collider != null)
            {
                if (ob.collider.gameObject != gameObject)
                {
                    ob.collider.SendMessage("GetPunch");
                }
            }
            

    }


}
