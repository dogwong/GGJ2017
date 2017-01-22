using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotionDetect : MonoBehaviour {
    public const float coolDown=1f;
    public const float previousCoolDown=.5f;

    public GameObject waves;

    public float previousWaveTime = 0f;
    public bool isJumpReady = false;
    public bool isPreviousPassed = true;
    public bool previousPositive = false;

    public float slashCoolDown = 0.0f;
    public bool slashRecording = false;

    List<float> listGyroYhistory = new List<float>();
    List<float> listLAcceYhistory = new List<float>();

    public static bool Attacking = false;

    void Awake()
    {
        Input.gyro.enabled = true;

        //Debug.Log("gyro interval = " + Input.gyro.updateInterval);
        
        //Screen.orientation = ScreenOrientation.LandscapeRight;
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
        isJumpReady = previousWaveTime > coolDown;

        //Debug.Log(Input.gyro.userAcceleration.y);
        //Debug.Log(Input.gyro.userAcceleration.x + "\t" + Input.gyro.userAcceleration.y + "\t" + Input.gyro.userAcceleration.z);
        //Debug.Log(Input.gyro.rotationRate.x + "\t" + Input.gyro.rotationRate.y + "\t" + Input.gyro.rotationRate.z);

        if (isJumpReady) {
            listGyroYhistory.Add(Input.gyro.rotationRate.y);
            if (listGyroYhistory.Count > 60) listGyroYhistory.RemoveAt(0);
            float gyroHighest = 0.0f;
            float gyroLowest = 0.0f;
            foreach (float f in listGyroYhistory) {
                if (f > gyroHighest) gyroHighest = f;
                else if (f < gyroLowest) gyroLowest = f;
            }
            if (gyroHighest - gyroLowest >= 20.0f) {
                Debug.Log("FLIP!");
                for (int i = 0; i < listGyroYhistory.Count; i++) {
                    listGyroYhistory[i] = 0.0f;
                }
            }
        } else {
            if (listGyroYhistory.Count > 0) listGyroYhistory.Clear();
        }

        if (slashRecording) {
            if (Input.gyro.userAcceleration.y < 1.0f) {
                slashRecording = false;
                float lowestY = 0.0f;
                float total = 0.0f;
                int qty = 0;
                float avg = (total / qty);
                foreach (float f in listLAcceYhistory) {
                    if (f < lowestY) lowestY = f;
                    total += f;
                    qty++;
                    Debug.Log(f);
                }
                Debug.LogWarning("SLASH! length = " + listLAcceYhistory.Count + "\tlowest = " + lowestY + "\tavg = " + (total / qty));
                Attacking = false;
                GameObject w = PhotonNetwork.Instantiate(this.waves.name, transform.position, Quaternion.identity, 0);
                WaveSize ws;
                if (avg < 2.0f) {
                    ws = WaveSize.Weak;
                } else if (avg < 3.0f) {
                    ws = WaveSize.Mild;
                } else {
                    ws = WaveSize.Huge;
                }
                w.GetComponent<WaveMono>().SetupWave(ws);

            } else {
                if (listLAcceYhistory[listLAcceYhistory.Count - 1] != Input.gyro.userAcceleration.y)
                    listLAcceYhistory.Add(Input.gyro.userAcceleration.y);
                //Debug.Log(Input.gyro.userAcceleration.y);
            }
        } else if (Input.gyro.userAcceleration.y >= 2.2f && !slashRecording) {
            slashRecording = true;
            listLAcceYhistory.Clear();
            listLAcceYhistory.Add(Input.gyro.userAcceleration.y);
            Debug.LogWarning("START SLASH");
            Attacking = true;
        }


        //if (isJumpReady && Mathf.Abs(Input.gyro.userAcceleration.x) > 1.5f)
        //{
        //    if (Input.gyro.userAcceleration.x > 0 && previousPositive)
        //        return;

        //    if (Input.gyro.userAcceleration.x < 0 && !previousPositive)
        //        return;

        //    TouchJump.instance.Jump();
        //        Debug.Log("Wave " + Input.gyro.userAcceleration.x+ " pre pos"+previousPositive);
        //    previousPositive = Input.gyro.userAcceleration.x>0;
        //    previousWaveTime = 0f;
        //    isPreviousPassed = false;
        //}

	}

}
