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
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        force = 12f;
        jumpForce = force + 2;
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

        if (col.gameObject.CompareTag("Finish")){
            SceneManager.LoadScene("Credits");
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
        if (Input.GetAxis("Vertical") > 0) {
            animator.SetBool("isRunning",true);
            transform.Translate ( (force * Vector3.forward) * Time.deltaTime, Camera.main.transform);
        }else {
            animator.SetBool("isRunning",false);
        }
        
        Jump();
    }

    private void Jump(){
        animator.SetBool("isRunning",false);
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping",true);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }else {
            animator.SetBool("isJumping",false);
        }
    }
}







// rb.AddForce(Camera.main.transform.forward * force * Time.deltaTime, ForceMode.VelocityChange);