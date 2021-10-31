using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialGameManager : MonoBehaviour
{
    public GameObject test;
    //UI
    public GameObject panel;
    public Text tips;
    public GameObject panel2;
    public Text congrats;
    public GameObject panel3;
    public Text press;

    public int testin;


    public GameObject center;
    public static List<GameObject> balls = Game_Manager.balls;
    public static List<GameObject> ballsTotal = Game_Manager.ballsTotal;
    public int realNumOfBalls;

    public Text numOfBall;
    public Text scoreInGame;
    public static int realScoreInTutorial;

    public GameObject ball;
    public GameObject target;
    public GameObject wizard;
    public GameObject witchcraft;
    public GameObject demonology;
    public GameObject sorcery;
    public GameObject theurgy;

    public static int tutorialTheurgyMultiplier;
    private static int tempScore;
    private static int currScore;

    public static int stageNum;
    
    private bool stageIsActive;
    // Start is called before the first frame update
    void Start()
    {
        panel2.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        congrats.color = new Vector4(0, 0, 0, 0);

        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        tips.color = new Vector4(0, 0, 0, 0);

        panel3.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        press.color = new Vector4(0, 0, 0, 0);

        stageIsActive = false;
        stageNum = 1;

        tempScore = 0;
        currScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreInGame.text = "" + realScoreInTutorial;

        if (currScore > 0)
        {
            if(balls.Count == 0)
            {
                realScoreInTutorial = currScore;
                tutorialTheurgyMultiplier = 0;
                tempScore = 0;
                currScore = 0;
            }
            //scoreInGame.text = "" + currScore;
        }
        

        realNumOfBalls = ballsTotal.Count;
        numOfBall.text = "" + realNumOfBalls;
        if (stageIsActive == false && stageNum == 1)
        {
            /*panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
            tips.color = new Vector4(50, 50, 50, 1);*/
            stageIsActive = true;
            //StartCoroutine(Delay());
            StageOne();
            
        }
        else if(stageIsActive == false && stageNum == 2)
        {
            stageIsActive = true;
            StageTwo();
        }
        else if (stageIsActive == false && stageNum == 3)
        {
            stageIsActive = true;
            StageThree();
        }
        else if (stageIsActive == false && stageNum == 4)
        {
            stageIsActive = true;
            StageFour();
        }
        else if (stageIsActive == false && stageNum == 5)
        {
            stageIsActive = true;
            StageFive();
            StartCoroutine(tip());
        }
        else if (stageIsActive == false && stageNum == 6)
        {
            stageIsActive = true;
            StageSix();
        }
        else if (stageIsActive == false && stageNum == 7)
        {
            stageIsActive = true;
            StageSeven();
            StartCoroutine(tip());
        }
        else if (stageIsActive == false && stageNum == 8)
        {
            stageIsActive = true;
            StageEight();
        }
        if (realNumOfBalls == 0)
        {
            realNumOfBalls = 9;
            for (int i = 0; i < realNumOfBalls; i++)
            {
                if (ballsTotal.Count <= realNumOfBalls)
                {
                    ballsTotal.Add(ball);

                }

            }
        }
        
        if (stageIsActive && stageNum == 3 && realScoreInTutorial < 2000)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(test.transform.position, 1.5f);
            testin = hitColliders.Length;
            if(hitColliders.Length == 8 && currScore < 1700 && realScoreInTutorial < 1700)
            {
                StartCoroutine(Wait2());

            }
            
        }
        if(stageNum == 8 && realScoreInTutorial >= 2000)
        {
            realScoreInTutorial = 0;
            SceneManager.LoadScene("StartingScreen");
            stageNum = 1;
            
        }
        else if(realScoreInTutorial >= 2000 && stageNum != 8)
        {
            
            StartCoroutine(Wait());
           
        }
        else if((stageNum == 5 && Input.GetKeyDown(KeyCode.N) || (stageNum == 7 && Input.GetKeyDown(KeyCode.N))))
        {
            StartCoroutine(Wait());
        }
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        panel2.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        congrats.color = new Vector4(0, 0, 0, 1);
        congrats.text = "STAGE ONE";
        yield return new WaitForSeconds(2f);
        panel2.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        congrats.color = new Vector4(0, 0, 0, 0);
        stageIsActive = true;
        StageOne();

    }
    IEnumerator tip()
    {
        yield return new WaitForSeconds(7f);
        panel3.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        press.color = new Vector4(0, 0, 0, 1);
    }

    IEnumerator Wait2()
    {
        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, 10f);
        //for each in array
        foreach (var hitCollider in hitColliders)
        {
            //check if it is regular peg
            if (hitCollider.gameObject.tag == "regularPeg")
            {
                termination temp = (termination)hitCollider.GetComponent(typeof(termination));
                temp.terminationOfTarget();

            }
            if (hitCollider.gameObject.tag == "Player")
            {
                shoot temp = (shoot)hitCollider.GetComponent(typeof(shoot));
                temp.terminationOfPlayer();

            }
            if (hitCollider.gameObject.tag == "DemonologyPeg")
            {
                Demonology temp = (Demonology)hitCollider.GetComponent(typeof(Demonology));
                temp.terminationOfDemon();

            }
            if (hitCollider.gameObject.tag == "wizard")
            {
                wizardry_peg temp = (wizardry_peg)hitCollider.GetComponent(typeof(wizardry_peg));
                temp.terminationOfWizard();

            }
            if (hitCollider.gameObject.tag == "witch")
            {
                witchcraft_peg temp = (witchcraft_peg)hitCollider.GetComponent(typeof(witchcraft_peg));
                temp.terminationOfWitch();

            }
        }
        yield return new WaitForSeconds(2f);
        stageIsActive = false;
    }

    IEnumerator Wait()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, 10f);
        //for each in array
        foreach (var hitCollider in hitColliders)
        {
            //check if it is regular peg
            if (hitCollider.gameObject.tag == "regularPeg")
            {
                termination temp = (termination)hitCollider.GetComponent(typeof(termination));
                temp.terminationOfTarget();

            }
            if (hitCollider.gameObject.tag == "Player")
            {
                shoot temp = (shoot)hitCollider.GetComponent(typeof(shoot));
                temp.terminationOfPlayer();

            }
            if (hitCollider.gameObject.tag == "DemonologyPeg")
            {
                Demonology temp = (Demonology)hitCollider.GetComponent(typeof(Demonology));
                temp.terminationOfDemon();

            }
            if (hitCollider.gameObject.tag == "wizard")
            {
                wizardry_peg temp = (wizardry_peg)hitCollider.GetComponent(typeof(wizardry_peg));
                temp.terminationOfWizard();

            }
            if (hitCollider.gameObject.tag == "witch")
            {
                witchcraft_peg temp = (witchcraft_peg)hitCollider.GetComponent(typeof(witchcraft_peg));
                temp.terminationOfWitch();

            }
        }
        realScoreInTutorial = 0;

        if(stageNum != 5 || stageNum != 7)
        { 
            panel2.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        congrats.color = new Vector4(0, 0, 0, 1);

        }
        panel3.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        press.color = new Vector4(0, 0, 0, 0);

        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        tips.color = new Vector4(0, 0, 0, 0);

        yield return new WaitForSeconds(2.5f);

        panel2.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
        congrats.color = new Vector4(0, 0, 0, 0);
        stageNum++; 
        
        stageIsActive = false;
    }

    public void StageOne()
    {

        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1f);
        tips.color = new Vector4(0, 0, 0, 1);
        //Instantiate()
        realNumOfBalls = 9;
        for(int i = 0; i < realNumOfBalls; i++)
        {
            if(ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }
            
        }
        numOfBall.text = "" + realNumOfBalls;
        Instantiate(target, new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1.5f, 1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.5f, -1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-5.5f, -1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.5f, -1.2f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-6, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-4, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-7, -3f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.5f, -1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1f, -2.2f, 0), Quaternion.identity);



    }
    public void StageThree()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "This green peg with the hat is a special peg called " +
            "the Witchcraft peg\n" +
            "The Witchcraft peg does the opposite of the Wizardry peg, " +
            "restoring all the surrounding pegs that have been hit\n" +
            "The Witchcraft and Wizardry pegs work well together, try it out\n" +
            "Score 2000 points to get to the next stage" +
            "You will not be able to go to the next stage if you will hit it before the Wizardry one!";

        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;
        Instantiate(wizard, new Vector3(-2f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
        Instantiate(witchcraft, new Vector3(-3f, -0.5f, 0), Quaternion.identity);

        


    }
    public void StageFour()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "This red peg with the horns is the Demonology peg.\n" +
            "\n" +
            " When you hit this with a ball, two more balls will be summoned " +
            "onto the field, allowing you to hit potentially three times the pegs!\n"
            + "\n" +
            "Score 2000 points to get to the next stage";
        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;

        Instantiate(demonology, new Vector3(-0.5f, -0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1.3f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-0.6f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.1f, -3f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.8f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.5f, -3, 0), Quaternion.identity);

        Instantiate(demonology, new Vector3(-7.5f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-8f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-7.3f, -3f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-6.6f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-5.9f, -3f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-5.2f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-4.5f, -3, 0), Quaternion.identity);


    }
    public void StageFive()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.fontSize = 20;
        tips.text = "For this stage you will not be able to rotate the ball shooter.\n" +
            "If you fire a ball, you will not be able to hit any pegs, your ball is too small.\n" +
            "Try to hit pegs";
        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;
        
        Instantiate(target, new Vector3(-3.77f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -4, 0), Quaternion.identity);




    }
    public void StageSix()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        
        tips.text = "This Purple fractal peg is a Sorcery Peg\n" +
            "If you hit this peg with a ball, that ball will grow " +
            "in size for a short period of time\n" +
            "This will help you to hit those hard to reach balls in this stage\n" +
            "Score 2000 points to advance to the next stage";

        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;
        Instantiate(sorcery, new Vector3(-3.29f, 2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3.77f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.77f, -4, 0), Quaternion.identity);




    }

    public void StageSeven()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        
        tips.text = "For this stage you will no be able to rotate the turret\n" +
            " \n" +
            "If you shoot a ball, it will bounce between these four pegs, but " +
            "it won’t be enough to pass this stage.";

        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;

        Instantiate(target, new Vector3(-3.4f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.34f, -1.65f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1.64f, -1.65f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.66f, -3.52f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.1f, -3.63f, 0), Quaternion.identity);






    }

    public void StageEight()
    {
        tips.fontSize = 17;
        tips.text = "That’s where this angelic yellow peg comes in.\n" +
            " This is the Theurgy peg, and while it won’t score you" +
            " points from hitting it, it will give a 3 times multiplier " +
            "to any peg that the ball that hit the Theurgy peg.\n" +
            "This will allow you to advance through the stage, even" +
            " with the smaller amount of score generating pegs.\n" +
            "Score 2000 points to finish the tutorial.";

        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;

        Instantiate(theurgy, new Vector3(-3.4f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.34f, -1.65f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1.64f, -1.65f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.66f, -3.52f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0.1f, -3.63f, 0), Quaternion.identity);






    }
    public void StageTwo()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "This grey peg with a dagger on it is a special peg called a Wizardry peg\n" +
            "When a ball hits this peg it destroys all the nearby pegs around it" +
            ", scoring the points you would gain from hitting those pegs\n" +
            "You also get 1000 points for hitting the Wizardry peg\n" +
            "Score 2000 points to proceed";
            
        realScoreInTutorial = 0;
        realNumOfBalls = 9;
        for (int i = 0; i < realNumOfBalls; i++)
        {
            if (ballsTotal.Count <= realNumOfBalls)
            {
                ballsTotal.Add(ball);

            }

        }
        numOfBall.text = "" + realNumOfBalls;
        Instantiate(wizard, new Vector3(0.5f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-1f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.5f, 0.5f, 0), Quaternion.identity);

        Instantiate(wizard, new Vector3(-6.5f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-5f, 0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-7.5f, 0f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-5f, -0.5f, 0), Quaternion.identity);


    }

    public static void AddScore(int score)
    {
        tempScore += score;
        if (tutorialTheurgyMultiplier > 0)
        {
            currScore = realScoreInTutorial + (tempScore * tutorialTheurgyMultiplier);
        }
        else
        {
            currScore = realScoreInTutorial + tempScore;
        }
    }
}
