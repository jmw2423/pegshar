using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialGameManager : MonoBehaviour
{
    //UI
    public GameObject panel;
    public Text tips;
    public GameObject panel2;
    public Text congrats;
    public GameObject panel3;
    public Text press;


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

    public static int theurgyRoundsTutorial;

    public  int stageNum;
    
    private bool stageIsActive;
    // Start is called before the first frame update
    void Start()
    {
        panel2.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        congrats.color = new Vector4(0, 0, 0, 0);

        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        tips.color = new Vector4(0, 0, 0, 0);

        panel3.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        press.color = new Vector4(0, 0, 0, 0);

        stageIsActive = false;
        stageNum = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreInGame.text = "" + realScoreInTutorial;

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
        if(stageNum == 8 && realScoreInTutorial >= 2000)
        {
            realScoreInTutorial = 0;
            SceneManager.LoadScene("StartingScreen");
            
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
        panel2.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        congrats.color = new Vector4(0, 0, 0, 1);
        congrats.text = "STAGE ONE";
        yield return new WaitForSeconds(2f);
        panel2.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        congrats.color = new Vector4(0, 0, 0, 0);
        stageIsActive = true;
        StageOne();

    }
    IEnumerator tip()
    {
        yield return new WaitForSeconds(7f);
        panel3.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        press.color = new Vector4(0, 0, 0, 1);
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
        }
        realScoreInTutorial = 0;

        if(stageNum != 5 || stageNum != 7)
        { 
            panel2.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        congrats.color = new Vector4(0, 0, 0, 1);

        }
        panel3.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        press.color = new Vector4(0, 0, 0, 0);

        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        tips.color = new Vector4(0, 0, 0, 0);

        yield return new WaitForSeconds(2.5f);

        panel2.GetComponent<Image>().color = new Vector4(1, 0, 0, 0);
        congrats.color = new Vector4(0, 0, 0, 0);
        stageNum++; 
        
        stageIsActive = false;
    }

    public void StageOne()
    {

        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
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
        Instantiate(target, new Vector3(2, 1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(3, 1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0, 1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.5f, -1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(3.5f, -1.2f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(6, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-4, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(0, -3f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(5f, -1.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(8f, -1.2f, 0), Quaternion.identity);



    }
    public void StageThree()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "This special peg is called WitchCraft peg\n" +
            "If you will hit this peg - all surrounding basic pegs will be restored\n" +
            "You can combine this peg with Wizard one to achieve best result!\n" +
            "Score 2000pt to get to the next stage";
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
        Instantiate(wizard, new Vector3(5, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(3.5f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(3.5f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(6.5f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(6, 1.5f, 0), Quaternion.identity);
        Instantiate(witchcraft, new Vector3(2, -0.5f, 0), Quaternion.identity);

        /*Instantiate(wizard, new Vector3(-2.5f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-4.5f, 0f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-0.5f, 1.5f, 0), Quaternion.identity);*/


    }
    public void StageFour()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "This special peg is called Demonology peg\n" +
            "If you will hit this peg - demons will summon two additional pegs in the game instantly and will help you get more points\n" +
            "Score 2000pt to get to the next stage";
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

        Instantiate(demonology, new Vector3(4f, -0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(3f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(4f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(5f, -4f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(6f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(7f, -4, 0), Quaternion.identity);

        Instantiate(demonology, new Vector3(-4f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-3, -4f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-4f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-5f, -4f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-6f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-7f, -4, 0), Quaternion.identity);


    }
    public void StageFive()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "For this stage you can not rotate turret\n" +
            "If you will shoot a peg - you will not get any hits, because your peg is too small\n" +
            "Try to hit basic pegs";
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
        //Instantiate(sorcery, new Vector3(1.85f, 2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -4, 0), Quaternion.identity);




    }
    public void StageSix()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "This special peg is called Sorcery peg\n" +
            "If you will hit this peg - your peg will become larger for 3 seconds\n" +
            "This will help you to hit those stone pegs\n" +
            "Score 2000pt to get to the next stage";
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
        Instantiate(sorcery, new Vector3(1.85f, 2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -2, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -3, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2.42f, -4, 0), Quaternion.identity);
        Instantiate(target, new Vector3(1.23f, -4, 0), Quaternion.identity);




    }

    public void StageSeven()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
        tips.color = new Vector4(0, 0, 0, 1);
        tips.text = "For this stage you can not rotate turret\n" +
            "If you will shoot a peg - you will hit four basic pegs\n" +
            "However, as each basic peg scores 300pt, you will not get nessesary 2000pt to pass this stage\n" +
            "Try to hit basic pegs";
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

        Instantiate(target, new Vector3(1.59f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(5.19f, -1.9f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.1f, -1.28f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2f, -4.1f, 0), Quaternion.identity);






    }

    public void StageEight()
    {
        tips.text = "This special peg is called Theurgy peg\n" +
            "If you will hit this peg - you will activate 3x score-multiplier for a limited time\n" +
            "This will help you to score 2000pt by hitting just three stone pegs\n" +
            "Score 2000pt to finish tutorial";
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
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

        Instantiate(theurgy, new Vector3(1.59f, -1, 0), Quaternion.identity);
        Instantiate(target, new Vector3(5.19f, -1.9f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-2.1f, -1.28f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(2f, -4.1f, 0), Quaternion.identity);






    }
    public void StageTwo()
    {
        panel.GetComponent<Image>().color = new Vector4(1, 0, 0, 0.5f);
        tips.color = new Vector4(50, 50, 50, 1);
        tips.text = "This special peg is called Wizardry peg\n" +
            "If you hit this peg - all surrounding basic pegs will be automatically scored\n" +
            "Additionaly you will get 1000pt for hitting this special peg itself\n" +
            "Score 2000pt to get to the next stage";
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
        Instantiate(wizard, new Vector3(5, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(3.5f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(6.5f, 0, 0), Quaternion.identity);
        Instantiate(target, new Vector3(6, 1.5f, 0), Quaternion.identity);

        Instantiate(wizard, new Vector3(-2.5f, -0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-0.5f, 0.5f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-4.5f, 0f, 0), Quaternion.identity);
        Instantiate(target, new Vector3(-0.5f, 1.5f, 0), Quaternion.identity);


    }

    public static void AddScoreTutorial(int score)
    {
        if (theurgyRoundsTutorial > 0)
        {
            realScoreInTutorial += (score * 3);
        }
        else
        {
            realScoreInTutorial += score;
        }
        //
    }
}
