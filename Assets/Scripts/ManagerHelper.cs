using UnityEngine;
using System.Collections;

public class ManagerHelper : MonoBehaviour {

	public Transform [] spawnPoints;
	// Use this for initialization
	void Start () {
		int index = PhotonNetwork.player.ID-1;
		if (index % 2 == 0) {
			GameObject player = PhotonNetwork.Instantiate ("Team1Player", 
				spawnPoints [index].position,
				spawnPoints [index].rotation,
				0);
			GameObject.FindGameObjectWithTag ("Team1Camera").GetComponent<Camera> ().enabled = true;
		} else {
			GameObject player = PhotonNetwork.Instantiate ("Team2Player", 
				spawnPoints [index].position,
				spawnPoints [index].rotation,
				0);
			GameObject.FindGameObjectWithTag ("Team2Camera").GetComponent<Camera> ().enabled = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
