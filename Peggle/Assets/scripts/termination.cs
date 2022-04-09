using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class termination : MonoBehaviour
{
    //Variables
    public bool active;
    bool disabled;
    public GameObject regularBall;
    public SpriteRenderer targetColor;
    public static List<GameObject> balls = Game_Manager.balls;
    public static List<GameObject> summonedBalls = Game_Manager.summonedBalls;
    Color myColor = new Color(1, 0, 0, 1);
    Color startColor = new Color(1, 1, 1, 1);
    public Collider2D coll;
    public PhysicsMaterial2D phys;
    public PhysicsMaterial2D phys2;

    void Start()
    {
        targetColor = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        //sets startin bounciness
        //1.1
        coll.sharedMaterial.bounciness = 0.9f;
        active = true;
        disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //realScore = Game_Manager.realScoreInGame;
        //destroying them and those only when the are no player's peg on screen(between shots)
        //and which color is red
        if (balls.Count == 0 && summonedBalls.Count == 0 && targetColor.color == myColor)
        {

            //Destroy(regularBall);
            /*active = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            disabled = true;*/
            Magic1();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Magic2();
        }
        //swappes physics. We want to have less bounce from hitted pegs
        if(targetColor.color == myColor)
        {
            this.coll.sharedMaterial = phys;
        }
        //swappes it back if not hit(after restart)
        if (targetColor.color != myColor)
        {
            this.coll.sharedMaterial = phys;
        }

    }
    //changes color of ball if it was hit by player peg
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "summonedPlayer")
        {
            if(active)
            {
                //+300 score if regular peg was hit
                Game_Manager.AddScore(300);
                tutorialGameManager.AddScore(300);
                Debug.Log("RED");
                targetColor.color = myColor;
                active = false;
                //Debug.Log("WHATTT");
            }
            else if(disabled)
            {
                Debug.Log("EXCUSE ME");
                Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>(), true);
            }
            
        }

    }
    //I know this cs is called termination but its nice that its put in here
    public void Activate()
    {
        active = true;
        disabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        targetColor.color = startColor;
    }
    public void Magic1()
    {
        active = false;
    }
    public void Magic2()
    {
        disabled = true;
    }
    public void terminationOfTarget()
    {
        Destroy(regularBall);
    }
}
