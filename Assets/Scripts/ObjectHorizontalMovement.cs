using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHorizontalMovement : MonoBehaviour
{
    public GameObject obj, leftLimit, rightLimit;
    private bool isOnRight;
    public float movementForce;
    // Start is called before the first frame update
    void Start()
    {
        isOnRight = false;
        movementForce = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnRight)
        {
            moveLeft();
        }
        else
        {
            moveRight();
        }

    }

    private void moveRight()
    {
        obj.transform.position += new Vector3(+movementForce, 0, 0);
        if (obj.transform.position.x > rightLimit.transform.position.x)
        {
            isOnRight = true;
        }
    }

    private void moveLeft()
    {
        obj.transform.position += new Vector3(-movementForce, 0, 0);
        if (obj.transform.position.x < leftLimit.transform.position.x)
        {
            isOnRight = false;
        }
    }
}
