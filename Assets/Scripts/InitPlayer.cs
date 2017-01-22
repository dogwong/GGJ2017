using UnityEngine;
using System.Collections;

public class InitPlayer : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject teamOneCam;
    public GameObject teamTwoCam;
	// Use this for initialization
	void Start () {


        int index = PhotonNetwork.player.ID;

        Debug.Log(index);
		if (index == 1)
        {
            GameObject player = PhotonNetwork.Instantiate("Team1Player1",
                spawnPoints[index].position,
                spawnPoints[index].rotation,
                0); 
			PhotonNetwork.playerName = "Player" + PhotonNetwork.player.ID;
            //GameObject.FindGameObjectWithTag("Team1Camera").GetComponent<Camera>().enabled = true;
           teamOneCam.SetActive(true);
        }
		else if(index == 2)
        {
			GameObject player = PhotonNetwork.Instantiate("Team2Player2",
                spawnPoints[index].position,
                spawnPoints[index].rotation,
                0);
            //GameObject.FindGameObjectWithTag("Team2Camera").GetComponent<Camera>().enabled = true;
            teamTwoCam.SetActive(true); 
			PhotonNetwork.playerName = "Player" + PhotonNetwork.player.ID;
		} else if (index == 3)
		{
			GameObject player = PhotonNetwork.Instantiate("Team1Player3",
				spawnPoints[index].position,
				spawnPoints[index].rotation,
				0); 
			PhotonNetwork.playerName = "Player" + PhotonNetwork.player.ID;
			//GameObject.FindGameObjectWithTag("Team1Camera").GetComponent<Camera>().enabled = true;
			teamOneCam.SetActive(true);
		}
		else if(index == 4)
		{
			GameObject player = PhotonNetwork.Instantiate("Team2Player4",
				spawnPoints[0].position,
				spawnPoints[0].rotation,
				0);
			//GameObject.FindGameObjectWithTag("Team2Camera").GetComponent<Camera>().enabled = true;
			teamTwoCam.SetActive(true); 
			PhotonNetwork.playerName = "Player" + PhotonNetwork.player.ID;
		}
        Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
