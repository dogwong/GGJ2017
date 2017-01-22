using UnityEngine;
using System.Collections;

public class Launcher : Photon.PunBehaviour {

	string _gameVersion = "3543";
	public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;
	public GameObject controlPanel;
	public GameObject progressLabel;
	bool isConnecting;

	void Awake(){
		PhotonNetwork.autoJoinLobby = false;
		PhotonNetwork.automaticallySyncScene = true;
		PhotonNetwork.logLevel = Loglevel;
	}
	// Use this for initialization
	void Start () {
		progressLabel.SetActive(false);
		controlPanel.SetActive(true);
	}

	public void Connect(){
		isConnecting = true;
		progressLabel.SetActive(true);
		controlPanel.SetActive(false);
		if (PhotonNetwork.connected)
		{
			// #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnPhotonRandomJoinFailed() and we'll create one.
			PhotonNetwork.JoinRandomRoom();
		}else{
			// #Critical, we must first and foremost connect to Photon Online Server.
			PhotonNetwork.ConnectUsingSettings(_gameVersion);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void OnConnectedToMaster()
	{
		if (isConnecting)
		{
			// #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnPhotonRandomJoinFailed()
			PhotonNetwork.JoinRandomRoom();
		}
		Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
	}


	public override void OnDisconnectedFromPhoton()
	{
		progressLabel.SetActive(false);
		controlPanel.SetActive(true);
		Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");        
	}
	public override void OnPhotonRandomJoinFailed (object[] codeAndMsg)
	{
		Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

		// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
		PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 4 }, null);
	}

	public override void OnJoinedRoom()
	{
		Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        if (PhotonNetwork.room.PlayerCount == 1)
		{
			Debug.Log("We load the 'Room for 1' ");
			PhotonNetwork.LoadLevel("wave");
		}
	}
}
