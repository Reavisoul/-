using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public Text maxscore;
    private int score;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Maxscore");
        maxscore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
