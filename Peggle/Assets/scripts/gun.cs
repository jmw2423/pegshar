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

    //
    //private float theta;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

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

                //Instantiate(ball, barrel.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector3(Mathf.Cos(turret.transform.rotation.z), -1 * Mathf.Sin(turret.transform.rotation.z), 0) * 500);
                Instantiate(ball, barrel.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(turret.transform.up * -500);

                //adding ball to the list since we shot one
                balls.Add(ball);
            }
        }
        faceMouse();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SorceryPeg")
        {
            this.gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
    }
    
    void faceMouse()
    {
        /*if(tutorialGameManager.stageNum !=5 && tutorialGameManager.stageNum != 6 && tutorialGameManager.stageNum != 7 && tutorialGameManager.stageNum != 8)
        {
           

        }
        else if (tutorialGameManager.stageNum == 5 || tutorialGameManager.stageNum == 6 || tutorialGameManager.stageNum == 7 || tutorialGameManager.stageNum == 8)
        {
            transform.up = new Vector3(0, 0, 0);
        }*/
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y);

        transform.up = -direction;



    }
}
