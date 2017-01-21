using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera instance;
    const float shakeTime = 1f;
    float shakedTime = 0f;
    bool isShaking = false;


    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {

            shakedTime += Time.deltaTime;

            if (shakedTime >= shakeTime)
            {
                isShaking = false;
            }

        }
    }

    public void Shake()
    {
        isShaking = true;
        shakedTime = 0;
    }

}
