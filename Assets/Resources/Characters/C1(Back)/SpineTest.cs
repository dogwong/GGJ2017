
﻿using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SpineTest : MonoBehaviour {

	// Use this for initialization
	private SkeletonAnimation skeletonAnimation;

	[SpineAnimation]
	public string idle;

	[SpineAnimation]
	public string attack;

    public enum AnimationState { 
        Attack01=0,Attack02=1,Hit=2,Idle_Fast=3,Idle_Slow=4,Jump=5
    }

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation> ();
		skeletonAnimation.loop = true;
		skeletonAnimation.AnimationName = idle;
		skeletonAnimation.state.Complete += delegate {
			if (!checkAnimationAvilable()) {
				skeletonAnimation.loop = true;
				skeletonAnimation.AnimationName = idle;
			}
		};
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            //skeletonAnimation.loop =true;
            //skeletonAnimation.AnimationName = AnimationState.Jump.ToString();
            //PlayerNetworkManager.action = "jump";;
            Jump();
		}

	}

    public void Jump()
    {
        skeletonAnimation.state.AddAnimation(0, AnimationState.Jump.ToString(), false, 0);
        skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Slow.ToString(), true, 0);
    }
    public void Attack()
    {
        skeletonAnimation.state.AddAnimation(0, AnimationState.Attack01.ToString(), false, 0);
        skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Slow.ToString(), true, 0);
    }
    public void Injured()
    {

        skeletonAnimation.state.AddAnimation(0, AnimationState.Hit.ToString(), false, 0);
        skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Slow.ToString(), true, 0);
    }
    public bool checkAnimationAvilable()
    {
        Debug.Log("Current name"+skeletonAnimation.AnimationName);
        return skeletonAnimation.AnimationName == "Idle_Slow" || skeletonAnimation.AnimationName == "Idle_Fast";
    }
    public bool checkIsDodging()
    {
        return skeletonAnimation.AnimationName == "Jump";
	}

		
}
