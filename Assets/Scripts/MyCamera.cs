using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public float delay;
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;
    private float turnSpeed = 5.0f;
    private float yOffset = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        // initalOffset = transform.position - targetObject.position;
        initalOffset = new Vector3(targetObject.position.x,targetObject.position.y ,targetObject.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        // yaw += 2.0f * Input.GetAxis("Mouse X");
        // pitch -= 2.0f * Input.GetAxis("Mouse Y");

        // transform.eulerAngles = new Vector3(pitch,yaw,0.0f);
    }

    void FixedUpdate()
    {
        // cameraPosition = targetObject.position + initalOffset;
        // transform.position = cameraPosition;
        initalOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * initalOffset;
        transform.position = targetObject.position + initalOffset; 
        transform.LookAt(targetObject.position);
    }
}
