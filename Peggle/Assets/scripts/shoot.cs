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
        coll.sharedMaterial.bounciness -= 0.0002f;
        if (ball.transform.position.y < -6)
        {
            coll.sharedMaterial.bounciness = 0.9f;
            Destroy(ball);
            ballsTotal.RemoveAt(ballsTotal.Count - 1);
            balls.Clear();
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
            //coll.sharedMaterial.bounciness += 0.1f;
        }
        /*if (collision.tag == "regularPegHit")
        {
            coll.sharedMaterial.bounciness = 0.2f;
        }*/
        if (collision.tag == "SorceryPeg")
        {
            //this.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            StartCoroutine(Increase());
        }
    }

    private IEnumerator Increase()
    {

           
            this.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
           
            yield return new WaitForSeconds(4f);
            this.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
           
           
        

    }



}
