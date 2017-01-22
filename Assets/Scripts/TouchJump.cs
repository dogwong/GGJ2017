using UnityEngine;
using System.Collections;

public class TouchJump : MonoBehaviour {
    public static TouchJump instance;
	public GameObject waves;
    public float jumpMagnitude=10f;
    public bool isInvincible=false;
    public const float InvincibleTime=1f;
    public float inviciblePass = 0f;
	// Use this for initialization
	void Start () {
        instance = this;
        //if (GameManager.isTeamOne())
        //{ 
            
        //}
        //Debug.LogError(gameObject.name);
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D))
            Jump();
        else if (Input.GetKeyDown(KeyCode.A))
            SendWave();
	}

    public void SendWave()
    {
        SendWave(WaveSize.Mild);
    }
    public void SendWave(WaveSize waveSize)
    {

        SpineTest s=GetSpineTest();
        if(s!=null)
        {
            if(s.checkAnimationAvilable())
            {
            
            GameObject w = PhotonNetwork.Instantiate(this.waves.name,transform.position, transform.rotation, 0);
                 w.GetComponent<WaveMono>().SetupWave(waveSize);
                s.Attack();
            }
        }
        
         //new Vector3(0f, 5f, 0f)
        //w.GetComponent<Rigidbody>().velocity = w.transform.forward * -6;
        //Destroy(w, 5.0f);
    }
    public void Jump()
    {
        Debug.Log("Jumping");
        //GetComponent<Rigidbody>().velocity=(Vector3.up * jumpMagnitude);
        SpineTest s=GetSpineTest();
        if(s!=null)
        {
            Debug.Log("Spine found");
            if(s.checkAnimationAvilable())
            {
                Debug.Log("Spine avil");
                s.Jump();
            }
        }
        
    }
    public bool CheckIsInvincible()
    {
        SpineTest s = GetSpineTest();
        return s != null && s.checkIsDodging();
    }



    public SpineTest GetSpineTest()
    { 
        SpineTest[] spineTests=GetComponentsInChildren<SpineTest>();
        for (int i = 0; i < spineTests.Length; i++)
        {
            if (spineTests[i].enabled && spineTests[i].gameObject.GetActive()&&spineTests[i].GetComponent<MeshRenderer>().enabled)
                return spineTests[i];
        }
        return null;
    }
}
