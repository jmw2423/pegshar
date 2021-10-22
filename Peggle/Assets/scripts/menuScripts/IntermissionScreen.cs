using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntermissionScreen : MonoBehaviour
{

    public Button NextLevelButton;
    public Button exitButton;
    public Button tutorialButton;

    public static int numOfScene;
    public static List<GameObject> balls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        NextLevelButton.onClick.AddListener(NextLevel);
        exitButton.onClick.AddListener(ExitTheGame);
        tutorialButton.onClick.AddListener(StartTheTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void NextLevel()
    {
        
        if (numOfScene < SceneManager.sceneCountInBuildSettings - 3)
        {
            SceneManager.LoadScene(numOfScene + 1);
            balls.Clear();

        }

    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
