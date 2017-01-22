<<<<<<< HEAD
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> 36271bfabb5c44cc67a1733577195129b4fa9bf7
using System.Collections;
using Spine.Unity;

public class SpineTest : MonoBehaviour {

	// Use this for initialization
	private SkeletonAnimation skeletonAnimation;

	[SpineAnimation]
	public string idle;

	[SpineAnimation]
	public string attack;

<<<<<<< HEAD
    public enum AnimationState { 
        Attack01=0,Attack02=1,Hit=2,Idle_Fast=3,Idle_Slow=4,Jump=5
    }

=======
>>>>>>> 36271bfabb5c44cc67a1733577195129b4fa9bf7
	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation> ();
		skeletonAnimation.loop = true;
		skeletonAnimation.AnimationName = idle;
		skeletonAnimation.state.Complete += delegate {
			if (skeletonAnimation.AnimationName== attack) {
				skeletonAnimation.loop = true;
				skeletonAnimation.AnimationName = idle;
			}
		};
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            //skeletonAnimation.loop =true;
            //skeletonAnimation.AnimationName = AnimationState.Jump.ToString();
            //PlayerNetworkManager.action = "jump";;
            
            skeletonAnimation.state.AddAnimation(1, AnimationState.Jump.ToString(), false, 0);
            skeletonAnimation.state.AddAnimation(0, AnimationState.Idle_Fast.ToString(), true, 
            skeletonAnimation.skeletonDataAsset.duration[(int)AnimationState.Jump]);
		}

	}

    public void Jump()
    {
        skeletonAnimation.loop = false;
        skeletonAnimation.AnimationName = AnimationState.Jump.ToString();
        
        PlayerNetworkManager.action = "jump";
    }
    public void Attack()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = attack;
        PlayerNetworkManager.action = "attack";
    }
    public void Injured()
    { 
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
=======
		if (Input.GetKeyUp(KeyCode.A)) {
			skeletonAnimation.loop = true;
			skeletonAnimation.AnimationName = attack;
			PlayerNetworkManager.action = "attack";
		} 
	}

		
>>>>>>> 36271bfabb5c44cc67a1733577195129b4fa9bf7
}
