using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Must be added if using SceneManager functions
using UnityEngine.SceneManagement;
// Must be added if using UI functions
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Creates a class variable to keep track of 'GameManager' instance
    static GameManager _instance = null;

    [SerializeField] private int _score;
    public Text scoreText;

    public int currentLevel = 1;
    public int lastLevel = 1;
    // Start is called before the first frame update
    void Start()
    {

        // Check if 'GameManager' instance exists
        if (instance)
            // 'GameManager' already exists, delete copy
            Destroy(gameObject);
        else
        {
            // 'GameManager' does not exist so assign a reference to it
            instance = this;

            // Do not destroy 'GameManager' on Scene change
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if 'Escape' was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (SceneManager.GetActiveScene().name == "EndGame")
            {
                QuitGame();
            }
            else
            {
                NextLevel();
            }
        }
    }
    public static GameManager instance
    {
        get { return _instance; }   // can also use just 'get;'
        set { _instance = value; }  // can also use just 'set;'
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void NextLevel()
    {
        if (currentLevel != lastLevel)
        {
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);
            Text [] texts = Component.FindObjectsOfType<Text>();
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].tag == "Score")
                {
                    scoreText = texts[i];
                    break;
                }
            }
        }
        else
            SceneManager.LoadScene("EndGame");
    }

    public void Respawn()
    {
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void QuitGame()
    {
        // Display a message that the game is quitting
        Debug.Log("Quitting...");

        // Quits game (only works on EXE, not in Editor)
        Application.Quit();
    }

    public int score
    {
        get { return _score; }      // can also use just 'get;'
        set
        {
            _score = value;       // can also use just 'set;'

            // Check if 'scoreText' was set before trying to update HUD
            if (scoreText)
                // Update HUD on every score change
                scoreText.text = "Score: " + score;
        }
    }

}
