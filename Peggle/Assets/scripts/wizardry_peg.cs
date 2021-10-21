using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wizardry_peg : MonoBehaviour
{
    //public static int realScoreInGame;// = termination.realScore;
    //prefab
    public GameObject wizardBall;

    
    //color of prefab
    public SpriteRenderer wizardBallColor;
    //new color
    Color myColor1 = new Color(1, 0, 0, 1);
    Color myColor = new Color(1, 1, 1, 1);
    //list of wizard balls on the screen. Taking initial values from Game_Manager script
    //public static List<GameObject> wizardBalls = Game_Manager.numOfWizardBall;


    // Start is called before the first frame update
    void Start()
    {
        
        wizardBallColor = GetComponent<SpriteRenderer>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if our peg touches wizzard ball - we destroy wizard peg + all regular around
        if(collision.tag == "Player")
        {
            //score from hitting wizard peg
            Game_Manager.AddScore(1000);
            //creating array of colliders around wizard peg
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, 2f);
            //for each in array
            foreach(var hitCollider in hitColliders)
            {
                //check if it is regular peg
                if(hitCollider.gameObject.tag == "regularPeg")
                {
                    //if it is, updating score by value of regular peg and destroying regular peg
                    //somehow it doubles(score), so I made it 150 instead of 300
                    Game_Manager.AddScore(150);

                    Destroy(hitCollider.gameObject);

                }
                
            }
            //starting destruction func for wizard peg
            StartCoroutine(Waiting());
            
        }
    }
    private IEnumerator Waiting()
    {
       //changing color of wizard ball
        wizardBallColor.color = myColor1;
        //waiting 0.7 seconds
        yield return new WaitForSeconds(0.15f);

        wizardBallColor.color = myColor;

        yield return new WaitForSeconds(0.15f);

        wizardBallColor.color = myColor1;

        yield return new WaitForSeconds(0.15f);
        //destroying prefab
        Destroy(wizardBall);

        //updating list of balls by decreasing count
        //wizardBalls.RemoveAt(wizardBalls.Count - 1);
    }
}
