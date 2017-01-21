using UnityEngine;
using System.Collections;

public class TouchJump : MonoBehaviour {
    public static TouchJump instance;
	public GameObject waves;
	// Use this for initialization
	void Start () {
        instance = this;
        Debug.LogError(gameObject.name);
	}

	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Jump();

        //}
	}

    public void Jump()
    {

        GameObject w = PhotonNetwork.Instantiate(this.waves.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);

        w.GetComponent<Rigidbody>().velocity = w.transform.forward * -6;

        Destroy(w, 5.0f);
    }
}
