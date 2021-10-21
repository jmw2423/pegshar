using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    //scene manager

    //public static numOfScene = Ga
    public Text numOfBall;
    public Text scoreInGame;
    //score counter in the game. Takes all scores from other classes
    public static int realScoreInGame;
    private int realNumOfBall;
    public GameObject ball;
    public GameObject wizardBall;

    //public static List<GameObject> numOfWizardBall = new List<GameObject>();
    //list of Player's pegs in game at the moment
    public static List<GameObject> balls = new List<GameObject>();
    //list of availible pegs for player
    public static List<GameObject> ballsTotal = new List<GameObject>();
    GameObject[] wizardBalls;
    private int numOfWizardBalls;
    public int numOfBalls;

    //menu transition flow
        //levelnames
    public string levelNameLose;
    public string levelNameWin;
    //buttons
    //starting menu buttons
    /*public Button startButton;
    public Button exitButton;
    public Button nextLevelButton;*/



    // Start is called before the first frame update
    void Start()
    {
        balls.Clear();
        //menu transitions
        /*startButton.onClick.AddListener(StartTheGame);
        exitButton.onClick.AddListener(ExitTheGame);
        nextLevelButton.onClick.AddListener(NextLevel);*/

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
        IntermissionScreen.numOfScene = SceneManager.GetActiveScene().buildIndex;
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
        //game over scene
        if (realNumOfBall == 0)
        {
            SceneManager.LoadScene(levelNameLose);

        } 
        //intermission
        if(realScoreInGame >= 1000)
        {
            SceneManager.LoadScene(levelNameWin);
        }
    }

    //menu transitions
    /*public void StartTheGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }*/
}
