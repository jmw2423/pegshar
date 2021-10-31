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

    private float stuckTime;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        stuckTime = 0;
        coll = GetComponent<Collider2D>();
        coll.sharedMaterial.bounciness = 0.67f;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position == lastPos)
        {
            stuckTime += Time.deltaTime;
        }
        else
        {
            stuckTime = 0;
        }

        if(stuckTime >= 3)
        {
            ballsTotal.Remove(ball);
            Destroy(ball);
            balls.Clear();
        }

        lastPos = ball.transform.position;

        if (ball.transform.position.y < -6)
        {
            Destroy(ball);
            ballsTotal.RemoveAt(ballsTotal.Count - 1);
            balls.Clear();
            //Game_Manager.gameInPlay = false;
        }
        coll.sharedMaterial.bounciness = 0.67f;
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
        this.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
           
        yield return new WaitForSeconds(4f);
        this.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void terminationOfPlayer()
    {
        Destroy(ball);
        balls.Clear();
    }



}
