using UnityEngine;
using System.Collections;
using System;

public class AnimationManagerScript : MonoBehaviour {

    private Animator anim;
    private float idleTimer;
    //private bool walking = false;
    private bool wall = false;
    private bool groundedSwitch = false;
    private bool countering = false;
    private bool blinking = false;

    public enum State { NORMAL, RUN, ATTACK, THROW, SHOOT, COUNTER, WALLON, IDLE, ERR }

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        idleTimer += Time.deltaTime;
        if (idleTimer >= 10)
        {
            idleTimer = 0;
            anim.SetTrigger("idle");
        }

        //Debug.Log("Curent state: " + GetState().ToString());
	}

    public State GetState()
    {
        int currentStateHash = anim.GetCurrentAnimatorStateInfo(0).nameHash;
        if (currentStateHash == Animator.StringToHash("Base.normal"))
            return State.NORMAL;
        if (currentStateHash == Animator.StringToHash("Base.run"))
            return State.RUN;
        if (currentStateHash == Animator.StringToHash("Base.attack1") ||
            currentStateHash == Animator.StringToHash("Base.attack2") ||
            currentStateHash == Animator.StringToHash("Base.attack3")) 
            return State.ATTACK;
        if (currentStateHash == Animator.StringToHash("Base.throw"))
            return State.THROW;
        if (currentStateHash == Animator.StringToHash("Base.shoot"))
            return State.SHOOT;
        if (currentStateHash == Animator.StringToHash("Base.counter"))
            return State.COUNTER;
        if (currentStateHash == Animator.StringToHash("Base.wallon"))
            return State.WALLON;
        if (currentStateHash == Animator.StringToHash("Base.idle"))
            return State.IDLE;

        return State.ERR;
    }

    public void Shoot()
    {
        anim.SetTrigger("shoot");
        idleTimer = 0;
        //walking = false;
    }

    public void Throw()
    {
        anim.SetTrigger("throw");
    }

    public void Counter()
    {
        anim.SetTrigger("counter");
        idleTimer = 0;
        //walking = false;
        countering = true;
    }

    public void StopCounter()
    {
        anim.SetTrigger("normal");
        idleTimer = 0;
        countering = false;
    }


    public void WallOn()
    {
        anim.SetTrigger("wallon");
        wall = true;
        idleTimer = 0;
    }

    public void WallOf()
    {
        Normal();
        wall = false;
        //if (walking)
        //{
        //    //walking = false;
        //}
        idleTimer = 0;
    }

    public void Normal()
    {
        anim.SetTrigger("normal");
        idleTimer = 0;
    }

    public void Attack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger("attack");
        }
        else if (attack == 1)
        {
            anim.SetTrigger("attack2");
        }
        else if (attack == 2)
        {
            anim.SetTrigger("attack3");
        }
        
    }

    public void Dash(float horMove, float verMove)
    {
        if (horMove == 0 && verMove == 1)
        {
            anim.SetTrigger("dashforward");
        }
        if (horMove == 0 && verMove == -1)
        {
            anim.SetTrigger("dashbackward");
        }
        if (horMove == -1 && verMove == 0)
        {
            anim.SetTrigger("dashleft");
        }
        if (horMove == 1 && verMove == 0)
        {
            anim.SetTrigger("dashright");
        }
        blinking = true;
    }

    public void StopDash()
    {
        blinking = false;
        anim.SetTrigger("normal");
    }

    public void move(float verMove, float horMove, bool grounded)
    {
        if (countering)
        {
            return;
        }

        if (verMove != 0 || horMove != 0)
        {
            idleTimer = 0;
        }

        if (!grounded && !groundedSwitch)
        {
            //walking = false;
            if (!wall)
            {
                Normal();
            }
            groundedSwitch = true;
        }

        if (grounded && groundedSwitch)
        {
            groundedSwitch = false;
        }

        if (!grounded)
        {
            return;
        }

        //if (!walking)
        //{
        //    if (verMove != 0 || horMove != 0)
        //    {
        //        walking = true;
        //        if (!wall)
        //        {
        //            anim.SetTrigger("run");
        //        }
                
        //    }
        //}
        else
        {
            if (verMove == 0 && horMove == 0)
            {
                //walking = false;
                if (!wall)
                {
                    Normal();
                }
            }
        }
    }

}
