using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        Destroy(collision.gameObject,1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
