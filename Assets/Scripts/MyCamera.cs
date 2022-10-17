using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initOffset;
    private Vector3 cameraPosition;
    private float turnSpeed = 5.0f;
    // private float yOffset = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        initOffset = new Vector3(targetObject.position.x,targetObject.position.y ,targetObject.position.z);
    }

    void FixedUpdate()
    {
        initOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * initOffset;
        transform.position = targetObject.position + initOffset; 
        transform.LookAt(targetObject.position);
    }
}
