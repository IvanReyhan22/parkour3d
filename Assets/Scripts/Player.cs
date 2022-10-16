using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    // public GameObject player;
    public float force, jumpForce;
    public Text starCount, liveCount;

    int score = 0;
    int lives = 3;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    { 
        force = 10f;
        jumpForce = force + 2;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        starCount.text = score.ToString();
        liveCount.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("destroyable"))
        {
            addScore();
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("FallBorder")){
            deductLive();
            transform.position = new Vector3(1,1,-7);
        }
    }

    void addScore(){
        score += 1;
        starCount.text = score.ToString();
    }

    void deductLive(){
        lives -= 1;
        liveCount.text = lives.ToString();
        if(lives == 0) {
            SceneManager.LoadScene("Finish");
        }
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * force, rb.velocity.y, verticalInput * force);
        if (Input.GetAxis("Vertical") > 0) {
            animator.SetBool("isRunning",true);
            rb.velocity = new Vector3(force * Time.deltaTime, 0);
            transform.Translate ( (force * Vector3.forward) * Time.deltaTime, Camera.main.transform);
            rb.AddForce(Camera.main.transform.forward * force * Time.deltaTime, ForceMode.VelocityChange);
        }else {
            animator.SetBool("isRunning",false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isRunning",false);
            animator.SetBool("isJumping",true);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }else {
            animator.SetBool("isJumping",false);
        }

    }
}
