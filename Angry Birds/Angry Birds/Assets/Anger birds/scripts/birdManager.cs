using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birdManager : MonoBehaviour
{
    private int nowLevel;
    private int totalLevel;

    public List<Bird> birds;
    public List<Pig> pigs;
    public static birdManager _birdinstance;//单例
    public static birdManager Instance { get => _birdinstance; set => _birdinstance = value; }
    private Vector3 origionPos;//初始鸟的位置
    public LineRenderer right;//右划线
    public LineRenderer left;//左划线
    public Transform rightLine;
    public Transform leftLine;
    public GameObject win;
    public GameObject lose;
    public GameObject pausepanel;
    public void Pause()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }

    public void Continue()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Reload()
    {
   
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Backtohome()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Nextlevel()
    {
        PlayerPrefs.SetInt("nowLevel", nowLevel);
        SceneManager.LoadScene(1);
        print(nowLevel);
        print(totalLevel);
    }

    private void opensp()
    {
        right.enabled = true;
        left.enabled = true;
    }

    //判定游戏逻辑
    public void NextBird()
    {
        if(pigs.Count >0)
        {
            if(birds.Count >0)
            {
                //下一只
                Init();
                Invoke("opensp", 0.05f);
            }
            else
            {
                //失败
                lose.SetActive(true);
            }
        }
        else
        {
            //成功
            win.SetActive(true);
            nowLevel += 1;
            print("nowLelveis"+nowLevel);
            SaveData();
        }
    }

    public void SaveData()
    {
        if(nowLevel>PlayerPrefs.GetInt("totalLevel"))
        {
            PlayerPrefs.SetInt("totalLevel", nowLevel);
            print("totalLevelis  "+PlayerPrefs.GetInt("totalLevel"));
        } 
    }




    //初始化
    private void Init()
    {
        for(int i=0; i<birds.Count;i++)
        {
            if (i == 0) 
            {
                birds[i].transform.position = origionPos;

                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
        nowLevel= PlayerPrefs.GetInt("nowLevel");
        totalLevel = PlayerPrefs.GetInt("totalLevel");
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void Awake()
    {
        Instance = this;
        if (birds.Count > 0)
        {
            origionPos = birds[0].transform.position;
        }
    }
     
    // Update is called once per frame
    void Update()
    {

    }
}
