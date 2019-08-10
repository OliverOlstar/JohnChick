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
    public int levelStartScore;
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
        if (SceneManager.GetActiveScene().name == "Title Screen")
        {
            Button[] buttons = FindObjectOfType<Canvas>().GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(StartGame);
            buttons[1].onClick.AddListener(QuitGame);
        }
        if (SceneManager.GetActiveScene().name == "Failed")
        {
            Button[] buttons = FindObjectOfType<Canvas>().GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(Respawn);
            buttons[1].onClick.AddListener(QuitGame);
        }
        else if (SceneManager.GetActiveScene().name == "End Game")
        {
            Button[] buttons = FindObjectOfType<Canvas>().GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(ToTitle);
            buttons[1].onClick.AddListener(QuitGame);
        }
        if (SceneManager.GetActiveScene().name == "Level" + currentLevel)
        {
            if (!scoreText)
            {
                Canvas canvas = FindObjectOfType<Canvas>();
                if (!canvas)
                    Debug.Log("No Canvas");
                Text[] texts = canvas.GetComponentsInChildren<Text>();
                if (!texts[0])
                    Debug.Log("No text");
                for (int i = 0; i < texts.Length; i++)
                {
                    if (texts[i].tag == "Score")
                    {
                        scoreText = texts[i];
                        scoreText.text = "Revenge Score: " + score;
                        break;
                    }
                    else
                        Debug.Log("Not Score");
                }
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
        currentLevel = 1;
        score = 0;
        SceneManager.LoadScene("Level1");
    }

    public void NextLevel()
    {
        if (currentLevel != lastLevel)
        {
            levelStartScore = score;
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);

        }
        else
            SceneManager.LoadScene("EndGame");
    }

    public void Respawn()
    {
        score = levelStartScore;
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
                scoreText.text = "Revenge Score: " + score;
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }

}
