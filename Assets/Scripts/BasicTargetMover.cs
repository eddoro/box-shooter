using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetMover : MonoBehaviour
{
    // Start is called before the first frame update
    public float spinSpeed = 180.0f;
    public float motionMagnitude = 0.01f;

    public bool doSpin = true;
    public bool doMotion = true;
    // Update is called once per frame
    void Update()
    {
        //rotate around the X axis of the game object
        if (doSpin)
        {
            this.gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

        //move up and down
        if (doMotion)
        {
            this.gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
        }
    }
}
