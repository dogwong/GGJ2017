using UnityEngine;
using System.Collections;

public class MotionDetect : MonoBehaviour {
    public float coolDown=1f;
    public float previousCoolDown=.5f;


    public float previousWaveTime = 0f;
    public bool isReady = false;
    public bool isPreviousPassed=true;
    public bool previousPositive=false;
    
    void Awake()
    {
        Input.gyro.enabled = true;
        
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Acc " + Input.gyro.userAcceleration);
        //Debug.Log("gravity " + Input.gyro.gravity);
        //Debug.Log("att " + Input.gyro.attitude);
        previousWaveTime += Time.deltaTime;
        isPreviousPassed = previousWaveTime > previousCoolDown;
        isReady = previousWaveTime > coolDown;
        


        if (isReady&&Mathf.Abs(Input.gyro.userAcceleration.z) >1.5f)
        {
            if (Input.gyro.userAcceleration.z > 0 && previousPositive)
                return;

            if (Input.gyro.userAcceleration.z < 0 && !previousPositive)
                return;
            TouchJump.instance.Jump();
                Debug.Log("Wave " + Input.gyro.userAcceleration.z+ " pre pos"+previousPositive);
            previousPositive=Input.gyro.userAcceleration.z>0;
            previousWaveTime = 0f;
            isPreviousPassed=false;
        }

	}

}