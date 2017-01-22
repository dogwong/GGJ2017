using UnityEngine;
using System.Collections;
using Spine.Unity;

public class SpineTest : MonoBehaviour {

	// Use this for initialization
	private SkeletonAnimation skeletonAnimation;

	[SpineAnimation]
	public string idle;

	[SpineAnimation]
	public string attack;

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
		if (Input.GetKeyUp(KeyCode.A)) {
			skeletonAnimation.loop = true;
			skeletonAnimation.AnimationName = attack;
			PlayerNetworkManager.action = "attack";
		} 
	}

		
}
