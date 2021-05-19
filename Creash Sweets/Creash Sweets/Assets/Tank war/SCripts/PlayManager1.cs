using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayManager1 : MonoBehaviour
{
    //两个玩家的属性值
    public int lifeValue1 = 3;
    public int playerScore1 = 0;
    public bool isDead1;
    public bool isDefeat1;
    public int lifeValue2 = 3;
    public int playerScore2 = 0;
    public bool isDead2;
    public bool isDefeat2;
    //引用项目
    public GameObject Born1;
    public Text player1ScoreText;
    public Text player1LifeValueText;
    public GameObject Born2;
    public Text player2ScoreText;
    public Text player2LifeValueText;
    public GameObject isDefeatUI;
    public GameObject continue1;

    //单例
    private static PlayManager1 instance;

    public static PlayManager1 Instance { get => instance; set => instance = value; }

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
    private void Awake()
    {
        Instance = this;
    }


    //返回主界面
    public void ReturnToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //复活1
    private void Recover1()
    {
        if (lifeValue1 <= 0)
        {
            isDefeat1 = true;
            //游戏失败,返回主界面
        }
        else
        {
            lifeValue1--;
            GameObject player1 = Instantiate(Born1, new Vector3(-2, -8, 0), Quaternion.identity);
            player1.GetComponent<Born>().createPlayer = true;
            isDead1 = false;
        }
    }

    //复活2
    private void Recover2()
    {
        if (lifeValue2 <= 0)
        {
            isDefeat2 = true;
            //游戏失败,返回主界面
        }
        else
        {
            lifeValue2--;
            GameObject player2 = Instantiate(Born2, new Vector3(2, -8, 0), Quaternion.identity);
            isDead2 = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat1&&isDefeat2)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToTheMainMenu", 3);
        }
        if (isDead1)
        {
            Recover1();
        }
        if(isDead2)
        {
            Recover2();
        }
        player1ScoreText.text = playerScore1.ToString();
        player1LifeValueText.text = lifeValue1.ToString();
        player2ScoreText.text = playerScore2.ToString();
        player2LifeValueText.text = lifeValue2.ToString();
    }
}
