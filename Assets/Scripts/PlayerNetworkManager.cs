using UnityEngine;
using System.Collections;

public class PlayerNetworkManager : Photon.MonoBehaviour
{


    void Awake()
    {
        GameObject team1Camera = GameObject.FindGameObjectWithTag("Team1Camera");
        GameObject team2Camera = GameObject.FindGameObjectWithTag("Team2Camera");
        if (photonView.isMine && (PhotonNetwork.player.ID == 1 || PhotonNetwork.player.ID == 3))
        {
            //team1Camera.GetComponent<AudioListener>().enabled = true;
            //team1Camera.GetComponent<GUILayer>().enabled = true;
            //team1Camera.GetComponent<FlareLayer>().enabled = true;
            GetComponent<TouchJump>().enabled = true;
        }
        else if (photonView.isMine && (PhotonNetwork.player.ID == 2 || PhotonNetwork.player.ID == 4))
        {
            //team2Camera.GetComponent<AudioListener>().enabled = true;
            //team2Camera.GetComponent<GUILayer>().enabled = true;
            //team2Camera.GetComponent<FlareLayer>().enabled = true;
            GetComponent<TouchJump>().enabled = true;
        }
        else
        {
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
            //stream.SendNext(transform.position);
            //stream.SendNext(transform.rotation);
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