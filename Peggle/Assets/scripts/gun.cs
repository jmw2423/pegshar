using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public GameObject turret;
    public GameObject ball;
    //transform component(end of the barrel position)
    public Transform barrel;
    //list of peg's on the screen. Need that to make sure only one can be on the screen at a time.
    public static List<GameObject> balls = Game_Manager.balls;
    public TrajectoryScript trajectory;

    public AudioSource shootSound;

    Vector3 ballForce;
    //
    //private float theta;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //ballForce = new Vector3(1 * Mathf.Cos(77 - turret.transform.rotation.z) * 2, -1 * Mathf.Cos(turret.transform.rotation.z), 0) * 500;
        ballForce = -transform.up * 500;

        //theta = turret.transform.rotation.z;
        //turret controls(currently limitations do not work and I dont know why)
        //maybe you have an idea
        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    /*if(turret.transform.rotation.z > -74)
        //    {
        //        turret.transform.Rotate(0, 0, -0.7f);
        //    }*/
        //    turret.transform.Rotate(0, 0, -0.7f);

        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (turret.transform.rotation.z < 74)
        //    {
        //        turret.transform.Rotate(0, 0, 0.7f);
        //    }
        //}
        //can shoot peg only if balls list is empty
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (balls.Count == 0)
            {
                shootSound.Play();
                //there are problems with addforce. I am not sure how to implement it correctly. Need rotational math
                Instantiate(ball, barrel.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(ballForce);
                //adding ball to the list since we shot one
                balls.Add(ball);
                //trajectory.Hide();
            }
        }
        faceMouse();
        if(balls.Count == 0)
        {
            trajectory.Show();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SorceryPeg")
        {
            this.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
    }
    
    void faceMouse()
    {
        Vector3 mousePosition;
        Vector2 direction;
        if (tutorialGameManager.stageNum !=5 && tutorialGameManager.stageNum != 6 && tutorialGameManager.stageNum != 7 && tutorialGameManager.stageNum != 8)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        
            transform.up = -direction;
            //Vector3 g = new Vector3(0.0f, 9.8f, 0.0f);
            //Vector3 newBallForce = (ballForce * g);
            ballForce.y -= 9.8f;
            trajectory.UpdateDots(barrel.transform.position, ballForce/100);

        }
        else if (tutorialGameManager.stageNum == 5 || tutorialGameManager.stageNum == 6 || tutorialGameManager.stageNum == 7 || tutorialGameManager.stageNum == 8)
        {
            transform.up = new Vector3(0, 0, 0);
        }
        direction = new Vector2(0.0f, 0.0f);
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if(mousePosition.y > 5.0f)
        {
            direction = new Vector2(
            mousePosition.x - transform.position.x,
            5.0f - transform.position.y);
        }
        else
        {
            direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
        }
    }
}
