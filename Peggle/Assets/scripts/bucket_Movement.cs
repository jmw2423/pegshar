using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucket_Movement : MonoBehaviour
{

    public GameObject bucket;
    //public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        //starting impulse
        bucket.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(1,0,0) * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //movement from left to right
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Left")
        {
            //bucket.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
            bucket.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(1, 0, 0) * 200);
        }
        if (collision.tag == "Right")
        {
            
            bucket.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(-1, 0, 0) * 200);
        }
    }
}
