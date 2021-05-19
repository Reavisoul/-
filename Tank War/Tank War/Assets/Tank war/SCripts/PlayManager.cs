using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayManager : MonoBehaviour
{
    //属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead;
    public bool isDefeat;
    //引用
    public GameObject Born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeatUI;
    //单例
    private static PlayManager instance;
    public GameObject continue1;

    public static PlayManager  Instance { get => instance; set => instance = value; }


    private void Awake()
    {
        Instance = this;
    }


    public void Pause()
    {
        continue1.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        continue1.SetActive(false);
        Time.timeScale = 1;
    }
    //返回主界面
    public void ReturnToTheMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //复活
    private void Recover()
    {
        if(lifeValue <=0)
        {
            isDefeat = true;
            Invoke("ReturnToTheMainMenu", 3);
            //游戏失败,返回主界面
        }
        else
        {
            lifeValue--;
            GameObject player1 = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            player1.GetComponent<Born>().createPlayer = true;
            isDead = false; 
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDefeat)
        {
            isDefeatUI.SetActive(true);
            return; 
        }
        if(isDead)
        {
            Recover();
        }
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text =lifeValue.ToString();
    }
}
