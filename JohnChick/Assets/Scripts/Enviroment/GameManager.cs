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

    public List<int> _score = new List<int>();
    //public List<int> levelStartScore;
    public Text scoreText;

    public int currentLevel ;
    public int lastLevel;
    // Start is called before the first frame update
    void Start()
    {

        // Check if 'GameManager' instance exists
        if (instance) { 
            // 'GameManager' already exists, delete copy
            Destroy(gameObject);
        }
        else
        {
            // 'GameManager' does not exist so assign a reference to it
            instance = this;

            // Do not destroy 'GameManager' on Scene change
            DontDestroyOnLoad(this);
        }

        _score = FindObjectOfType<ScoreCont>()._score;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if 'Escape' was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //else if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Pause();
        //}
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
            //buttons[0].onClick.AddListener(Respawn);
            buttons[1].onClick.AddListener(QuitGame);
        }
        else if (SceneManager.GetActiveScene().name == "End Game")
        {
            Button[] buttons = FindObjectOfType<Canvas>().GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(ToTitle);
            buttons[1].onClick.AddListener(QuitGame);
            Text [] texts = FindObjectOfType<Canvas>().GetComponentsInChildren<Text>();
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].tag == "Score")
                {
                    scoreText = texts[i];
                    scoreText.text = "";
                    break;
                }
                else
                    Debug.Log("Not Score");
            }
        }
        if (SceneManager.GetActiveScene().name == "Level" + currentLevel)
        {
            if (!scoreText)
            {
                //Canvas canvas = FindObjectOfType<Canvas>();
                //if (!canvas)
                //    Debug.Log("No Canvas");
                ////Text[] texts = canvas.GetComponentsInChildren<Text>();
                ////if (!texts[0])
                //    Debug.Log("No text");
                //for (int i = 0; i < texts.Length; i++)
                //{
                //    if (texts[i].tag == "Score")
                //    {
                //        scoreText = texts[i];
                //        scoreText.text = "";
                //        break;
                //    }
                //    else
                //        Debug.Log("Not Score");
                //}
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
        RawImage[] titleRawImg = FindObjectOfType<Canvas>().GetComponentsInChildren<RawImage>();
        titleRawImg[1].enabled = false;
        titleRawImg[2].enabled = true;
        currentLevel = 1;
        _score = null;
        SceneManager.LoadScene("Level1");
    }

    public void NextLevel()
    {
        if (currentLevel != lastLevel)
        {
            //levelStartScore = _score;
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);
            _score = FindObjectOfType<ScoreCont>()._score;
        }
        else
        {
            SceneManager.LoadScene("EndGame");
            _score = FindObjectOfType<ScoreCont>()._score;
        }
    }

    public void Respawn()
    {
        //_score = levelStartScore;
        SceneManager.LoadScene("Level" + currentLevel);
    }

    public void QuitGame()
    {
        // Display a message that the game is quitting
        Debug.Log("Quitting...");

        // Quits game (only works on EXE, not in Editor)
        Application.Quit();
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }

    //public void Pause()
    //{
    //    Time.timeScale = 0;
    //    Button[] buttons = FindObjectOfType<Canvas>().GetComponentsInChildren<Button>();
    //   RawImage[] buttonImg = FindObjectOfType<Canvas>().GetComponentsInChildren<RawImage>();

    //    buttons[0].onClick.AddListener(Resume);
    //    buttons[1].onClick.AddListener(ToTitle);
    //    buttonImg[0].enabled = true;
    //    buttonImg[1].enabled = true;

    //}

    public void Resume()
    {
        Time.timeScale = 1;
        RawImage[] buttonImg = FindObjectOfType<Canvas>().GetComponentsInChildren<RawImage>();
        buttonImg[0].enabled = false;
        buttonImg[1].enabled = false;
    }
}
