
﻿using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SpineA : SpineTest {

    public enum AnimationState { 
        Attack01=0,Attack02=1,Hit=2,Idle_Fast=3,Idle_Slow=4,Jump=5
    }

	

    public override  void Jump()
    {
        //skeletonAnimation.AnimationName = AnimationState.Jump.ToString();
        //skeletonAnimation.state.AddAnimation(0, AnimationState.Jump.ToString(), false, 0);

        Debug.Log("Jump");
        skeletonAnimation.AnimationName = AnimationState.Jump.ToString();
        skeletonAnimation.loop = false;
        //skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Slow.ToString(), true, 0);
    }
    public override void Attack()
    {
        Debug.Log("attack animation");
        skeletonAnimation.AnimationName = AnimationState.Attack01.ToString();
        skeletonAnimation.loop = false;
        //skeletonAnimation.state.AddAnimation(0, AnimationState.Attack01.ToString(), false, 0);
        //skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Slow.ToString(), true, 0);
    }
    public override void Injured()
    {

        skeletonAnimation.AnimationName = AnimationState.Hit.ToString();
        skeletonAnimation.loop = false;
        //skeletonAnimation.state.AddAnimation(0, AnimationState.Hit.ToString(), false, 0);
        //skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Slow.ToString(), true, 0);
    }
    public override void Idle()
    {
        if (skeletonAnimation.AnimationName != AnimationState.Idle_Slow.ToString())
        {
            skeletonAnimation.AnimationName = AnimationState.Idle_Slow.ToString();
            skeletonAnimation.loop = true;
        }
    }
    public override bool checkAnimationAvilable()
    {
        Debug.Log("Current name"+skeletonAnimation.AnimationName);
        return skeletonAnimation.AnimationName == "Idle_Slow" || skeletonAnimation.AnimationName == "Idle_Fast";
    }
    public override bool checkIsDodging()
    {
        return skeletonAnimation.AnimationName == "Jump";
	}

		
}
