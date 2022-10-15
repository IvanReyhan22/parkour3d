using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVerticalMovement : MonoBehaviour
{
    public GameObject obj, upLimit, bottomLimit;
    private bool isOnTop;
    private float movementForce;
    // Start is called before the first frame update
    void Start()
    {
        isOnTop = false;
        movementForce = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTop)
        {
            moveDown();
        }
        else
        {
            moveUp();
        }
    }

    private void moveDown()
    {
        obj.transform.position += new Vector3(0, -movementForce, 0);
        if (obj.transform.position.y < bottomLimit.transform.position.y)
        {
            isOnTop = false;
        }
    }

    private void moveUp()
    {
        obj.transform.position += new Vector3(0, +movementForce, 0);
        if (obj.transform.position.y > upLimit.transform.position.y)
        {
            isOnTop = true;
        }
    }
}
