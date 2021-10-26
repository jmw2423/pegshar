using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{

    public Button startButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartTheGame);
        exitButton.onClick.AddListener(ExitTheGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene("Level1");
        Game_Manager.theurgyRounds = 0;
    }

    public void ExitTheGame()
    {
        Game_Manager.theurgyRounds = 0;
        Application.Quit();
    }
}
