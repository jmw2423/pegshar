using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonology : MonoBehaviour
{

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(ball, this.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 1, 0) * 100);
            Instantiate(ball, this.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 1, 0) * 100);
            Destroy(this.gameObject);
        }
    }
}
