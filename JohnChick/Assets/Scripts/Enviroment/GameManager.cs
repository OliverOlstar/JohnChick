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
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider loadingBar;

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
    }

    public static GameManager instance
    {
        get { return _instance; }   // can also use just 'get;'
        set { _instance = value; }  // can also use just 'set;'
    }

    // Update is called once per frame
    void Update()
    {
        // Check if 'Escape' was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        //Switch John Chick Image
        RawImage[] titleRawImg = FindObjectOfType<Canvas>().GetComponentsInChildren<RawImage>();
        titleRawImg[1].enabled = false;
        titleRawImg[2].enabled = true;
        
        //Show load bar
        if (loadingBar && !loadingBar.gameObject.activeSelf)
            loadingBar.gameObject.SetActive(true);

        //Start loading next scene
        currentLevel = 1;
        StartCoroutine("LoadAsynchronously", currentLevel);
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //Load target scene
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level1");

        //Display load progress
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (loadingBar)
                loadingBar.value = progress;

            yield return null;
        }
    }

    public void NextLevel()
    {
        if (currentLevel != lastLevel)
        {
            //levelStartScore = _score;
            currentLevel++;
            SceneManager.LoadScene("Level" + currentLevel);
        }
        else
        {
            SceneManager.LoadScene("EndGame");
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

    //public void Resume()
    //{
    //    Time.timeScale = 1;
    //    RawImage[] buttonImg = FindObjectOfType<Canvas>().GetComponentsInChildren<RawImage>();
    //    buttonImg[0].enabled = false;
    //    buttonImg[1].enabled = false;
    //}
}
