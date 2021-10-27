using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demonology : MonoBehaviour
{

    public GameObject ball;
    public GameObject summonedBall;
    public static List<GameObject> summonedBalls = Game_Manager.summonedBalls;
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
        if(collision.tag == "Player" || collision.tag == "summonedPlayer")
        {
            Instantiate(summonedBall, this.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 1, 0) * 100);
            Instantiate(summonedBall, this.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 1, 0) * 100);
            for(int i = 0; i < 2; i++)
            {
                summonedBalls.Add(summonedBall);
            }
            Game_Manager.AddScore(500);
            tutorialGameManager.AddScore(500);
            Destroy(this.gameObject);
        }
    }
    public void terminationOfDemon()
    {
        Destroy(this.gameObject);
        
    }
}
