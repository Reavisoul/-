using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    private int choice=1;
    public Transform posOne;
    public Transform posTwo;
    public AudioClip ChoiceAudio;
    public GameObject help;


    public void QuitGame()
    {
        Application.Quit();
    }

    public void Help()
    {
        help.SetActive(true);
    }

    public void Back()
    {
        help.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            choice = 1;
            transform.position = posOne.position;
            AudioSource.PlayClipAtPoint(ChoiceAudio, transform.position);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            choice = 2;
            transform.position = posTwo.position;
            AudioSource.PlayClipAtPoint(ChoiceAudio, transform.position);
        }
        if (choice == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            AudioSource.PlayClipAtPoint(ChoiceAudio, transform.position);
        }
        else if(choice == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
            AudioSource.PlayClipAtPoint(ChoiceAudio, transform.position);
         }
    }
}
