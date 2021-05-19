using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private bool isSelect = false;
    public Sprite levelBG;
    private Image image;


    public GameObject panel;


    private void Init()
    {

        int totalLevel = PlayerPrefs.GetInt("totalLevel");
        int temp = int.Parse(gameObject.name);
        if (totalLevel >= temp)
        {
            isSelect = true;
        }
        if (isSelect)
        {
            image.overrideSprite = levelBG;
            transform.Find("num"+ int.Parse(gameObject.name)).gameObject.SetActive(true);
        }
        
    }


    public void Selected()
    {
        if(isSelect)
        {
            PlayerPrefs.SetInt("nowLevel", int.Parse(gameObject.name));
            SceneManager.LoadScene(5);
        }
    }

    // Start is called before the first frame update

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    
    
    
   private void Start()
    {
        Init();
    }

    // Update is called once per frame
    private void Update()
    {
    }

}
