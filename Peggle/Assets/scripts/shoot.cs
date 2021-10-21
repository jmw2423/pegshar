using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject ball;
    private GameObject barrel;
    public static List<GameObject> balls = Game_Manager.balls;
    public static List<GameObject> ballsTotal = Game_Manager.ballsTotal;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        coll.sharedMaterial.bounciness =0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        coll.sharedMaterial.bounciness-= 0.0002f;
        if (ball.transform.position.y < -6)
        {
            coll.sharedMaterial.bounciness = 0.9f;
            Destroy(ball);
            ballsTotal.RemoveAt(ballsTotal.Count - 1);
            balls.Clear();
            //Game_Manager.gameInPlay = false;
            if(Game_Manager.theurgyRounds > 0)
            {
                Game_Manager.theurgyRounds--;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bucket")
        {
            Destroy(ball);
            balls.Clear();
        }
        if(collision.tag == "wizard" || collision.tag == "regularPeg")
        {
            coll.sharedMaterial.bounciness += 0.1f;
        }
        /*if (collision.tag == "regularPegHit")
        {
            coll.sharedMaterial.bounciness = 0.2f;
        }*/
    }

}
