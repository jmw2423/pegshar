using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject ball;
    public static List<GameObject> balls = Game_Manager.balls;
    public static List<GameObject> ballsTotal = Game_Manager.ballsTotal;
    public Collider2D coll;

    public AudioSource hitSound;
    public AudioSource sorcSound;
    public AudioSource demonSound;
    public AudioSource theurgySound;
    public AudioSource witchSound;
    public AudioSource wizardSound;
    public AudioSource warlockSound;

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
            //Game_Manager.gameInPlay = false;
        }
        /*if(balls.Count == 0)
        {
            
        }*/
        coll.sharedMaterial.bounciness = 0.9f;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "regularPeg":
                if(collision.gameObject.GetComponent<termination>().active)
                {
                    hitSound.Play();
                }
                break;
            case "TheurgyPeg":
                theurgySound.Play();
                break;
            case "wizard":
                wizardSound.Play();
                break;
            case "SorceryPeg":
                //this.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                sorcSound.Play();
                StartCoroutine(Increase());
                break;
            case "witch":
                witchSound.Play();
                break;
            case "DemonologyPeg":
                demonSound.Play();
                break;
            case "WarlockPeg":
                warlockSound.Play();
                break;
            case "Bucket":
                Destroy(ball);
                balls.Clear();
                break;
            default:
                break;
        }       

        //if(collision.tag == "wizard" || collision.tag == "regularPeg")
        //{
        //    //coll.sharedMaterial.bounciness += 0.1f;
        //}
        //if (collision.tag == "regularPegHit")
        //{
        //    coll.sharedMaterial.bounciness = 0.2f;
        //}
    }

    private IEnumerator Increase()
    {
        this.gameObject.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
           
        yield return new WaitForSeconds(4f);
        this.gameObject.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
    }

    public void terminationOfPlayer()
    {
        Destroy(ball);
        balls.Clear();
    }



}
