
﻿using UnityEngine;
using System.Collections;
using Spine.Unity;

public abstract class SpineTest : MonoBehaviour {

	// Use this for initialization
	protected SkeletonAnimation skeletonAnimation;

	[SpineAnimation]
	public string idle;

	[SpineAnimation]
	public string attack;


	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation> ();
		skeletonAnimation.loop = true;
		skeletonAnimation.AnimationName = idle;
        //Spine.AnimationState.TrackEntryDelegate
        skeletonAnimation.state.Complete += delegate(Spine.TrackEntry trackEntry){
            Idle();
        };
	}
	
	// Update is called once per frame
	void Update () {
        

	}
    public abstract void Idle();

    public abstract void Jump();
    public abstract void Attack();
    public abstract void Injured();
    public abstract bool checkAnimationAvilable();
    public abstract bool checkIsDodging();

		
}
