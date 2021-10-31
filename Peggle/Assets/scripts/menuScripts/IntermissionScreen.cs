using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntermissionScreen : MonoBehaviour
{

    public Button NextLevelButton;
    public Button exitButton;
    //public Button tutorialButton;

    public Text narrative;

    public static int numOfScene;
    public static List<GameObject> balls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        NextLevelButton.onClick.AddListener(NextLevel);
        exitButton.onClick.AddListener(ExitTheGame);
        if (Game_Manager.previousScene == "Level-1")
        {
            narrative.text = "Level 2: City Hall Hearing\n" +
                "\n" +
                "A few days ago you got a parking ticket as you were " +
                "beginning to move your cart, and there�s only so much " +
                "one should be willing to take. You�ve come to city hall" +
                " to challenge the judge to a game of Pegshar so that you " +
                "don�t have to pay this fine that you don�t deserve. ";

        }
        if (Game_Manager.previousScene == "Level-2")
        {
            narrative.fontSize = 28;
            narrative.text = "Level 3: Theological argument\n" +
                "\n" +
                "After another fun night of drinking you have gotten " +
                "into a semi-coherent argument about whether Piskor " +
                "or Anjar is the better god. You normally would not be" +
                " able to stand strong against this much better foe, but" +
                " Pegshar requires no strength. Well, there�s the strength" +
                " of will in this world where everything is decided this way," +
                " but you�re having a great time, right? ";

        }
        if (Game_Manager.previousScene == "Level-3")
        {
            narrative.fontSize = 28;
            narrative.text = "Level 4: Auction Dispute \n" +
                "\n" +
                "You are tired of this last minute bidder swiping the " +
                "items you have your eyes on. This is the last straw." +
                " You need that commemorative plate to complete your set," +
                " and you will not have this rich kid take it for themselves." +
                " You might not want to do this to a child, but they have to " +
                "learn not to get between someone and their plate. ";

        }
        if (Game_Manager.previousScene == "Level-4")
        {
            narrative.fontSize = 28;
            narrative.text = "Level 5: Pets Discussion\n" +
                "\n" +
                "Back at the tavern, you have gotten into a heated argument" +
                " with the waitstaff even before your group has finished " +
                "giving your food orders. Dogs VS Cats, a tale as old as" +
                " time, and the reason that you are playing today�s game of" +
                " Pegshar. Defend your furred friends, you will not have them " +
                "be compared to those other beasts.  ";

        }
        if (Game_Manager.previousScene == "Level-5")
        {
            narrative.fontSize = 28;
            narrative.text = "Level 6: Marketplace Price Dispute \n" +
                "\n" +
                "$10 for a few fruits? Ridiculous! This is the last time " +
                "this market stall owner will push you around. You need to" +
                " save some money for your other errands! Who does this person" +
                " think they are? Show them who you are. ";

        }
        if (Game_Manager.previousScene == "Level-6")
        {
            narrative.fontSize = 28;
            narrative.text = "Level 7: Divorce Proceedings \n" +
                "\n" +
                "Your partner left one day. They don�t want to be together " +
                "with you anymore, maybe you agree, maybe you don�t. " +
                "The important thing is that the two of you don�t agree on who gets what." +
                " You want your plates, they want your plates, it�s a mess. " +
                "They don�t know how much you�ve been playing Pegshar, " +
                "and the fool challenged you to decide who gets what. " +
                "Show �em who�s boss";

        }
        if (Game_Manager.previousScene == "Level-7")
        {
            narrative.fontSize = 28;
            narrative.text = "Level 8: Cheating?!? \n" +
                "\n" +
                "You�ve been approached by an officer of the law." +
                " They say that there are rumors about a Pegshar " +
                "cheater around town, and this officer needs to make " +
                "sure that you, with your very good win record, are on " +
                "the up and up. This officer seems to know their stuff, " +
                "probably won�t be able to sneak anything past them. ";

        }
        //tutorialButton.onClick.AddListener(StartTheTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void StartTheTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Game_Manager.theurgyRounds = 0;
    }*/

    public void NextLevel()
    {
        
        if (numOfScene < SceneManager.sceneCountInBuildSettings - 3)
        {
            SceneManager.LoadScene(numOfScene + 1);
            balls.Clear();

        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }

    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
