using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    // public GameObject player;
    public float force, jumpForce;

    // Start is called before the first frame update
    void Start()
    { 
        force = 10f;
        jumpForce = force + 2;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("destroyable"))
        {
            Debug.Log("AHHH!");
        }
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * force, rb.velocity.y, verticalInput * force);
        // if (Input.GetAxis ("Vertical") > 0) {
        //     // rb.velocity = new Vector3(force * Time.deltaTime, 0);
        //     // transform.Translate ( (force * Vector3.forward) * Time.deltaTime, Camera.main.transform);
        //     rb.AddForce(Camera.main.transform.forward * 100f * Time.deltaTime, ForceMode.VelocityChange);
        // }

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

    }
}
