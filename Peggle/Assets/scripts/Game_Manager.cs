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
    public Text goalText;
    //score counter in the game. Takes all scores from other classes
    private static int tempScore;
    private static int currScore;
    public static int realScoreInGame;
    public int scoreToBeat;
    private int realNumOfBall;
    public GameObject ball;
    public GameObject wizardBall;

    //public static List<GameObject> numOfWizardBall = new List<GameObject>();
    //list of Player's pegs in game at the moment
    public static List<GameObject> balls = new List<GameObject>();
    public static List<GameObject> summonedBalls = new List<GameObject>();
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

    //Theurgy peg hit
    public static int theurgyMultiplier;
    public static int theurgyRounds;
    public AudioSource winSound;
    public AudioSource loseSound;

    // Start is called before the first frame update
    void Start()
    {
        goalText.text = ""+scoreToBeat;

        balls.Clear();
        //menu transitions
        /*startButton.onClick.AddListener(StartTheGame);
        exitButton.onClick.AddListener(ExitTheGame);
        nextLevelButton.onClick.AddListener(NextLevel);*/

        //takes current score from UI
        realScoreInGame = int.Parse(scoreInGame.text);
        tempScore = 0;
        currScore = 0;
        theurgyMultiplier = 0;
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
        if(currScore > 0)
        {
            scoreInGame.text = "" + currScore;
        }

        //updates amount of pegs left
        realNumOfBall = ballsTotal.Count;
        numOfBall.text = "" + realNumOfBall;

        //loads scences
        //game over scene
        if (balls.Count == 0)
        {
            if (currScore > 0)
            {
                realScoreInGame = currScore;
                currScore = 0;
                tempScore = 0;
                theurgyMultiplier = 0;
            }
            
            if (realNumOfBall == 0)
            {
                SceneManager.LoadScene(levelNameLose);
                loseSound.Play();
            }
            //intermission
            if (realScoreInGame >= scoreToBeat)
            {
                SceneManager.LoadScene(levelNameWin);
                winSound.Play();
            }
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
    public static void AddScore(int score)
    {
        tempScore += score;
        if(theurgyMultiplier > 0)
        {
            currScore = realScoreInGame + (tempScore * theurgyMultiplier);
        }
        else
        {
            currScore = realScoreInGame + tempScore;
        }
    }
}
