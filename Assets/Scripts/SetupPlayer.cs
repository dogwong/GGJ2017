using UnityEngine;
using System.Collections;

public class SetupPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("my tag " + tag);
        if (!GameManager.isTeamOne())
        {
            transform.GetChild(0).FindChild("Front").GetComponent<MeshRenderer>().enabled = tag.CompareTo("Team1") != 0;
            transform.GetChild(0).FindChild("Back").GetComponent<MeshRenderer>().enabled = tag.CompareTo("Team1") == 0;
        }

        else
        {
            transform.GetChild(0).FindChild("Front").GetComponent<MeshRenderer>().enabled = tag.CompareTo("Team2") != 0;
            transform.GetChild(0).FindChild("Back").GetComponent<MeshRenderer>().enabled = tag.CompareTo("Team2") == 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
