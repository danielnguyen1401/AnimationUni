using System;
using UnityEngine;

public class GolemAnimation : MonoBehaviour
{
    private Animator anim;
    private string SLEEP_END_ANIMATION = "sleep_end";
    private string IDLE_ANIMATION = "idle";
    private string WALK_PARAMETER = "Walk";
    private string ATTACK_1_PARAMETER = "Atk1";
    private string ATTACK_2_PARAMETER = "Atk2";
    private string JUMP_PARAMETER = "Jump";


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void PlayJump(bool jump)
    {
        anim.SetBool(JUMP_PARAMETER, jump);
    }

    public void Attack1()
    {
        anim.SetBool(ATTACK_1_PARAMETER, true);
    }

    public void EndAttack1()
    {
        anim.SetBool(ATTACK_1_PARAMETER, false);
    }

    public void Attack2()
    {
        anim.SetBool(ATTACK_2_PARAMETER, true);
    }

    public void EndAttack2()
    {
        anim.SetBool(ATTACK_2_PARAMETER, false);
    }

    public void PlayWalk(bool walk)
    {
        anim.SetBool(WALK_PARAMETER, walk);
    }

    public void EndSleep()
    {
        anim.Play(SLEEP_END_ANIMATION);
    }

    public void BeginIdle()
    {
        anim.Play(IDLE_ANIMATION);
    }
}