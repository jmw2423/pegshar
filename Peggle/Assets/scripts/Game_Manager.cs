using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Text numOfBall;
    public Text scoreInGame;
    //score counter in the game. Takes all scores from other classes
    public static int realScoreInGame;
    private int realNumOfBall;
    public GameObject ball;
    public GameObject wizardBall;
    //levelnames
    public string levelNameLose;
    public string levelNameWin;
    //public static List<GameObject> numOfWizardBall = new List<GameObject>();
    //list of Player's pegs in game at the moment
    public static List<GameObject> balls = new List<GameObject>();
    //list of availible pegs for player
    public static List<GameObject> ballsTotal = new List<GameObject>();
    GameObject[] wizardBalls;
    private int numOfWizardBalls;
    public int numOfBalls;
    


    // Start is called before the first frame update
    void Start()
    {
        //takes current score from UI
        realScoreInGame = int.Parse(scoreInGame.text);
        //sets amount of availible balls
        for(int i = 0; i < numOfBalls; i++)
        {
            ballsTotal.Add(ball);
        }
        realNumOfBall = 5;

        /*wizardBalls = GameObject.FindGameObjectsWithTag("wizard");
        numOfWizardBalls = wizardBalls.Length;
        for(int i = 0; i <= numOfWizardBalls; i++)
        {
            numOfWizardBall.Add(wizardBall);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //updates score
        
        

        //+1000p for destroying wizard ball
        /*if (numOfWizardBalls > numOfWizardBall.Count - 1)
        {
            realScoreInGame += 1000;
            numOfWizardBalls--;
        }*/
        //updates score
        scoreInGame.text = "" + realScoreInGame;
        

        //updates amount of pegs left
        realNumOfBall = ballsTotal.Count;
        numOfBall.text = "" + realNumOfBall;

        //loads scences
        if (realNumOfBall == 0)
        {
            SceneManager.LoadScene(levelNameLose);

        } 
        if(realScoreInGame >= 10000)
        {
            SceneManager.LoadScene(levelNameWin);
        }
    }
}
