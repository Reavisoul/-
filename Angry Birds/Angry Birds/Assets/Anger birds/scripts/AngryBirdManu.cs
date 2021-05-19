using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryBirdManu : MonoBehaviour
{
    public GameObject map;
    public GameObject help;
    public GameObject level;
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("totalLevel", 1);
        SceneManager.LoadScene(0);
    }

    public void Help()
    {
        help.SetActive(true);
    }

    public void CloseHelp()
    {
        help.SetActive(false);
    }
    public void StartGame()
    {
        map.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnToManu()
    {
        map.SetActive(false);
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
