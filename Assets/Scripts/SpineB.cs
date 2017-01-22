
﻿using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SpineB : SpineTest {

    public enum AnimationState { 
        attack01=0,attack02=1,hurt=2,idle=3,jump=4
    }

    public override void Idle()
    {

        if (skeletonAnimation.AnimationName != AnimationState.idle.ToString())
        {
            skeletonAnimation.AnimationName = AnimationState.idle.ToString();
            skeletonAnimation.loop = true;
        }
    }
    public override void Jump()
    {
        skeletonAnimation.AnimationName = AnimationState.jump.ToString();
        skeletonAnimation.loop = false;
    }
    public override void Attack()
    {
        skeletonAnimation.AnimationName = AnimationState.attack01.ToString();
        skeletonAnimation.loop = false;
    }
    public override void Injured()
    {

        skeletonAnimation.AnimationName = AnimationState.hurt.ToString();
        skeletonAnimation.loop = false;
    }
    public override bool checkAnimationAvilable()
    {
        Debug.Log("Current name" + skeletonAnimation.AnimationName);
        return skeletonAnimation.AnimationName == AnimationState.idle.ToString();
    }
    public override bool checkIsDodging()
    {
        return skeletonAnimation.AnimationName == AnimationState.jump.ToString();
    }
		
}
