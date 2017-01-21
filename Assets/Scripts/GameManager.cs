using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.SceneManagement; 

public class GameManager : Photon.PunBehaviour {


	public GameObject team1Player;
	public GameObject team2Player;
	// Use this for initialization
	void Start () {
		/*if (PhotonNetwork.playerName == "player1" || PhotonNetwork.playerName == "player2") {
			PhotonNetwork.Instantiate (this.team1Player.name, new Vector3 (0f, 5f, 0f), Quaternion.identity, 0);
			GameObject.FindGameObjectWithTag ("Team1Camera").GetComponent<Camera>().enabled=true;
		} else {
			PhotonNetwork.Instantiate (this.team2Player.name, new Vector3 (0f, 5f, 0f), Quaternion.identity, 0);
			GameObject.FindGameObjectWithTag ("Team2Camera").GetComponent<Camera>().enabled=true;
		}*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnLeftRoom()
	{
		SceneManager.LoadScene(0);
	}

	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}

	void LoadArena()
	{
		if ( ! PhotonNetwork.isMasterClient ) 
		{
			Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
		}
		Debug.Log( "PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount );
		PhotonNetwork.LoadLevel("Level");
	}

	public override void OnPhotonPlayerConnected( PhotonPlayer other  )
	{
		Debug.Log( "OnPhotonPlayerConnected() " + other.NickName ); // not seen if you're the player connecting
		if ( PhotonNetwork.isMasterClient ) 
		{
			Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected
			LoadArena();
		}
	}


	public override void OnPhotonPlayerDisconnected( PhotonPlayer other  )
	{
		Debug.Log( "OnPhotonPlayerDisconnected() " + other.NickName ); // seen when other disconnects
		if ( PhotonNetwork.isMasterClient ) 
		{
			Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnecteds
			LoadArena();
		}
	}
=======
using UnityEngine.SceneManagement;

public class GameManager : Photon.PunBehaviour
{

    public static GameManager instance;
    public GameObject team1Player;
    public GameObject team2Player;

    int teamHealth;
    int team1Health;
    int team2Health;


    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
        if (PhotonNetwork.playerName == "player1" || PhotonNetwork.playerName == "player2")
        {
            PhotonNetwork.Instantiate(this.team1Player.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            GameObject.FindGameObjectWithTag("Team1Camera").GetComponent<Camera>().enabled = true;
        }
        else
        {
            PhotonNetwork.Instantiate(this.team2Player.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            GameObject.FindGameObjectWithTag("Team2Camera").GetComponent<Camera>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadArena()
    {
        if (!PhotonNetwork.isMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);
        PhotonNetwork.LoadLevel("Level");
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer other)
    {
        Debug.Log("OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected
            LoadArena();
        }
    }


    public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
    {
        Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName); // seen when other disconnects
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnecteds
            LoadArena();
        }
    }

    public void TeamTakeDamage(bool isTeamOne,int damage)
    {
        ReduceHealthAnimation(isTeamOne, damage);
        if (isTeamOne)
        {
            team1Health -= damage;
        }
        if (!isTeamOne)
        { 
            team2Health -= damage;
        }
        if (team1Health <= 0 || team2Health <= 0)
            GameOver();

    }
    public void GameOver()
    { }
    public void ReduceHealthAnimation(bool isTeamOne, int damage)
    {   

    }
>>>>>>> 8ab100b172c00fa67ee4721004ef9076c5dd49fb
}
