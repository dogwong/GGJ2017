using UnityEngine;
using System.Collections;

public class InitPlayer : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject teamOneCam;
    public GameObject teamTwoCam;
	// Use this for initialization
	void Start () {


        int index = PhotonNetwork.player.ID - 1;

        Debug.Log(index);
        if (index % 2 == 0)
        {
            GameObject player = PhotonNetwork.Instantiate("Team1Player",
                spawnPoints[index].position,
                spawnPoints[index].rotation,
                0); 
           
            //GameObject.FindGameObjectWithTag("Team1Camera").GetComponent<Camera>().enabled = true;
           teamOneCam.SetActive(true);
        }
        else
        {
            GameObject player = PhotonNetwork.Instantiate("Team2Player",
                spawnPoints[index].position,
                spawnPoints[index].rotation,
                0);
            //GameObject.FindGameObjectWithTag("Team2Camera").GetComponent<Camera>().enabled = true;
            teamTwoCam.SetActive(true); 
            
        }
        Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
