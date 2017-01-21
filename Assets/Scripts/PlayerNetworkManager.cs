using UnityEngine;
using System.Collections;

public class PlayerNetworkManager : Photon.MonoBehaviour {

	void Awake(){
		if (photonView.isMine) {
			
		} else {
			
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
