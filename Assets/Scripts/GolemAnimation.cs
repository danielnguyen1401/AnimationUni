﻿using System;
using UnityEngine;

public class GolemAnimation : MonoBehaviour
{
    private Animator anim;
    private string SLEEP_END_ANIMATION = "sleep_end";
    private string IDLE_ANIMATION = "idle";
    private string WALK_PARAMETER = "Walk";

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
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