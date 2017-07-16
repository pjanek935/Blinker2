using UnityEngine;
using System.Collections;
using System;

public class AnimationManagerScript : MonoBehaviour {

    private Animator anim;
    private float idleTimer;

    public enum State { NORMAL, RUN, ATTACK, THROW, SHOOT, COUNTER, WALLON, IDLE, ERR }

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        idleTimer += Time.deltaTime;

        if (Input.anyKeyDown)
        {
            idleTimer = 0;
            if (GetState() == State.IDLE)
            {
                anim.SetTrigger("normal");
            }
        }

        if (idleTimer >= 4)
        {
            anim.SetTrigger("idle");
            idleTimer = 0;
        }
        
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
    }

    public void Throw()
    {
        anim.SetTrigger("throw");
        idleTimer = 0;
    }

    public void Counter()
    {
        anim.SetTrigger("counter");
        idleTimer = 0;
    }

    public void StopCounter()
    {
        anim.SetTrigger("normal");
        idleTimer = 0;
    }


    public void WallOn()
    {
        anim.SetTrigger("wallon");
        idleTimer = 0;
    }

    public void WallOf()
    {
        Normal();
        idleTimer = 0;
    }

    public void Normal()
    {
        anim.SetTrigger("normal");
        idleTimer = 0;
    }

    public void Attack()
    {
        anim.SetTrigger("attack");
        idleTimer = 0;
    }

    public void StopDash()
    {
        anim.SetTrigger("normal");
        idleTimer = 0;
    }

    public void Move(float speed)
    {
        anim.SetFloat("speed", speed);
        if (speed > 0.1)
            idleTimer = 0;

    }

}
