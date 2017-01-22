using UnityEngine;
using System.Collections;

public class WaveMono : MonoBehaviour {
    public WaveSize waveSize;
    public float destoryWaveTime = 5f;
    float waveStaying = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        waveStaying += Time.deltaTime;
        if (waveStaying >= destoryWaveTime)
            Destroy(this.gameObject);
	}
    public void SetupWave(WaveSize _waveSize)
    { 
        waveSize=_waveSize;
        GetComponent<Rigidbody>().velocity =  transform.forward * -6; 
        //switch (waveSize)
        //{ 
            
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        bool isTeamOne = tag == "Team1Wave";
        if ((isTeamOne && other.tag == "Team2Member")||(!isTeamOne&&other.tag=="Team1Member"))
        {
            Debug.Log("Hit opponent ");
            if (other.gameObject.GetComponent<Photon.MonoBehaviour>().photonView.isMine)
            {
                ShakeCamera.instance.Shake();
            }
            GameManager.instance.TeamTakeDamage(isTeamOne, 1);
        }
        Debug.Log("hitting " + other.name);
    }
}
