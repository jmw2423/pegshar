using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorceryPeg : MonoBehaviour
{
    public GameObject ball;
    private bool large;
    public static List<GameObject> balls = Game_Manager.balls;
    // Start is called before the first frame update
    void Start()
    {
        large = false;
        ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(this.gameObject);
            
        }
    }
   
 
}