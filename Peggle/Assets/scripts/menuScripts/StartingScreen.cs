using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour
{

    public Button startButton;
    public Button exitButton;
    public Button tutorialButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartTheGame);
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

    public void StartTheGame()
    {
        SceneManager.LoadScene("Level-0");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
