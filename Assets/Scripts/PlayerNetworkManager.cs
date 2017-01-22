using UnityEngine;
using System.Collections;

public class PlayerNetworkManager : Photon.MonoBehaviour
{

	static public string action="null";

    void Awake()
    {
        //if (photonView.isMine && (PhotonNetwork.player.ID == 1 || PhotonNetwork.player.ID == 3))
        //{
        //    //team1Camera.GetComponent<AudioListener>().enabled = true;
        //    //team1Camera.GetComponent<GUILayer>().enabled = true;
        //    //team1Camera.GetComponent<FlareLayer>().enabled = true;
        //    GetComponent<TouchJump>().enabled = true;
        //    GameObject [] backs = GameObject.FindGameObjectsWithTag("Back");
        //    for (int i=0; i<backs.Length; i++){
        //        backs [i].GetComponent<MeshRenderer>().enabled = true;
        //    }
        //}
        //else if (photonView.isMine && (PhotonNetwork.player.ID == 2 || PhotonNetwork.player.ID == 4))
        //{
        //    //team2Camera.GetComponent<AudioListener>().enabled = true;
        //    //team2Camera.GetComponent<GUILayer>().enabled = true;
        //    //team2Camera.GetComponent<FlareLayer>().enabled = true;
        //    GetComponent<TouchJump>().enabled = true;
        //    GameObject [] backs = GameObject.FindGameObjectsWithTag("Back");
        //    for (int i=0; i<backs.Length; i++){
        //        backs [i].GetComponent<MeshRenderer>().enabled = true;
        //    }
        //}
        //else
        //{
        //    GameObject [] fronts = GameObject.FindGameObjectsWithTag("Front");
        //    for (int i=0; i<fronts.Length; i++){
        //        fronts [i].GetComponent<MeshRenderer>().enabled = true;
        //    }
        //    StartCoroutine("UpdateData");
        //}




        if (photonView.isMine && (PhotonNetwork.player.ID == 1 || PhotonNetwork.player.ID == 3))
        {
            GetComponent<TouchJump>().enabled = true;
            GameObject[] backs = GameObject.FindGameObjectsWithTag("Back");
            for (int i = 0; i < backs.Length; i++)
            {
                backs[i].GetComponent<MeshRenderer>().enabled = true;
                Debug.Log(backs[i]);
            }
        }
        else if (photonView.isMine && (PhotonNetwork.player.ID == 2 || PhotonNetwork.player.ID == 4))
        {
            GetComponent<TouchJump>().enabled = true;
            GameObject[] backs = GameObject.FindGameObjectsWithTag("Back");
            for (int i = 0; i < backs.Length; i++)
            {
                backs[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {


            GameObject[] fronts = GameObject.FindGameObjectsWithTag("Front");

            for (int i = 0; i < fronts.Length; i++)
            {
                fronts[i].GetComponent<MeshRenderer>().enabled = true;
            }
            foreach (Transform child in transform)
            {
                Debug.Log("child: " + child.tag);
                if (child.CompareTag("Front"))
                {
                    Debug.Log("child: " + child.tag);
                    child.GetComponent<MeshRenderer>().enabled = false;
                }
            }

            /*GameObject [] myTeam = GameObject.FindGameObjectsWithTag ("Team1Player");
            foreach (GameObject obj in myTeam) {
                foreach (Transform child in obj.transform) {
                    if (child.CompareTag ("Front")) {
                        child.GetComponent<MeshRenderer> ().enabled = false;
                    } 
                    if (child.CompareTag ("Back")) {
                        child.GetComponent<MeshRenderer> ().enabled = true;
                    }
                }
            }*/
            StartCoroutine("UpdateData");
        } 
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdateData()
    {
        while (true)
        {
            //transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
            //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smoothing);

            yield return null;
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
			stream.SendNext(PhotonNetwork.playerName);
            stream.SendNext(action);
            //stream.SendNext(health);
        }
        else
        {
            //position = (Vector3)stream.ReceiveNext();
            //rotation = (Quaternion)stream.ReceiveNext();
            //health = (float)stream.ReceiveNext();
        }
    }

}