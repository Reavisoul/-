using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //单例模式
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; set => _instance = value; }

    //大网格的行列数
    public int xColumn;
    public int yRow;
    //获取糖果背景巧克力预制体
    public GameObject gridPrefab;
    public float fillTime;//填充时间

    //交换的两个甜品
    private GameSweet pressedSweet;
    private GameSweet enterSweet;
    //有关游戏UI显示的内容
    public Text timeText;
    private float gameTime = 60;
    private bool gameOver;
    public int playerScore = 0;
    public Text gameScore;
    public AudioClip gameAudio;
    public Text gameoverScore;

    //枚举甜品种类
    public enum SweetsType
    {
        EMPTY,
        NORMAL,
        BARRIER,
        ROW_CLEAR,
        COLUMN_CLEAR,
        RAINBOWCANDY,
        COUNT//标记类型
    }

    //甜品预制体字典 通过甜品种类得到对应物体
    public Dictionary<SweetsType, GameObject> sweetProfabDict;

    //让结构体显示在面板中，用来管理上面的字典
    [System.Serializable]
    public struct SweetPrefab
    {
        public SweetsType type;
        public GameObject prefab;
    }

    public SweetPrefab[] sweetPrefabs;

    //甜品数组
    private GameSweet[,] sweets;

    public GameObject GameOverPanel;
    public GameObject Pausepanel;




    public void ReturntoMain()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(6);
    }


    public void Pause()
    {
        Time.timeScale = 0;
        Pausepanel.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        Pausepanel.SetActive(false);
    }







    private void GameTimeandscore()
    {
        if (gameOver)
        {
            return;
        }
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            gameTime = 0;
            //游戏结束画面    
            gameoverScore.text = playerScore.ToString();
            int temp = PlayerPrefs.GetInt("Maxscore");
            if(playerScore>temp)
            {
                PlayerPrefs.SetInt("Maxscore", playerScore);
            }
            GameOverPanel.SetActive(true);
            gameOver = true;
            return;
        }
        timeText.text = gameTime.ToString("0");
        gameScore.text = playerScore.ToString();
    }





    //甜品匹配方法，匹配完成的甜品加入消除列表
    public List<GameSweet> MatchSweets(GameSweet sweet, int newX, int newY)
    {
        if (sweet.CanColor())
        {
            ColorSweet.ColorType color = sweet.ColoredComponent.Color;
            List<GameSweet> matchRowSweets = new List<GameSweet>();
            List<GameSweet> matchLineSweets = new List<GameSweet>();
            List<GameSweet> finishedMatchingSweets = new List<GameSweet>();

            //行匹配
            matchRowSweets.Add(sweet);

            //i=0代表往左，i=1代表往右
            for (int i = 0; i <= 1; i++)
            {
                for (int xDistance = 1; xDistance < xColumn; xDistance++)
                {
                    int x;
                    if (i == 0)
                    {
                        x = newX - xDistance;
                    }
                    else
                    {
                        x = newX + xDistance;
                    }
                    if (x < 0 || x >= xColumn)
                    {
                        break;
                    }

                    if (sweets[x, newY].CanColor() && sweets[x, newY].ColoredComponent.Color == color)
                    {
                        matchRowSweets.Add(sweets[x, newY]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (matchRowSweets.Count >= 3)
            {
                for (int i = 0; i < matchRowSweets.Count; i++)
                {
                    finishedMatchingSweets.Add(matchRowSweets[i]);
                }
            }

            //L T型匹配
            //检查一下当前行遍历列表中的元素数量是否大于3
            if (matchRowSweets.Count >= 3)
            {
                for (int i = 0; i < matchRowSweets.Count; i++)
                {
                    //行匹配列表中满足匹配条件的每个元素上下依次进行列遍历
                    // 0代表上方 1代表下方
                    for (int j = 0; j <= 1; j++)
                    {
                        for (int yDistance = 1; yDistance < yRow; yDistance++)
                        {
                            int y;
                            if (j == 0)
                            {
                                y = newY - yDistance;
                            }
                            else
                            {
                                y = newY + yDistance;
                            }
                            if (y < 0 || y >= yRow)
                            {
                                break;
                            }

                            if (sweets[matchRowSweets[i].X, y].CanColor() && sweets[matchRowSweets[i].X, y].ColoredComponent.Color == color)
                            {
                                matchLineSweets.Add(sweets[matchRowSweets[i].X, y]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (matchLineSweets.Count < 2)
                    {
                        matchLineSweets.Clear();
                    }
                    else
                    {
                        for (int j = 0; j < matchLineSweets.Count; j++)
                        {
                            finishedMatchingSweets.Add(matchLineSweets[j]);
                        }
                        break;
                    }
                }
            }

            if (finishedMatchingSweets.Count >= 3)
            {
                return finishedMatchingSweets;
            }

            matchRowSweets.Clear();
            matchLineSweets.Clear();

            matchLineSweets.Add(sweet);

            //列匹配

            //i=0代表往左，i=1代表往右
            for (int i = 0; i <= 1; i++)
            {
                for (int yDistance = 1; yDistance < yRow; yDistance++)
                {
                    int y;
                    if (i == 0)
                    {
                        y = newY - yDistance;
                    }
                    else
                    {
                        y = newY + yDistance;
                    }
                    if (y < 0 || y >= yRow)
                    {
                        break;
                    }

                    if (sweets[newX, y].CanColor() && sweets[newX, y].ColoredComponent.Color == color)
                    {
                        matchLineSweets.Add(sweets[newX, y]);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (matchLineSweets.Count >= 3)
            {
                for (int i = 0; i < matchLineSweets.Count; i++)
                {
                    finishedMatchingSweets.Add(matchLineSweets[i]);
                }
            }

            //L T型匹配
            //检查一下当前行遍历列表中的元素数量是否大于3
            if (matchLineSweets.Count >= 3)
            {
                for (int i = 0; i < matchLineSweets.Count; i++)
                {
                    //行匹配列表中满足匹配条件的每个元素上下依次进行列遍历
                    // 0代表上方 1代表下方
                    for (int j = 0; j <= 1; j++)
                    {
                        for (int xDistance = 1; xDistance < xColumn; xDistance++)
                        {
                            int x;
                            if (j == 0)
                            {
                                x = newY - xDistance;
                            }
                            else
                            {
                                x = newY + xDistance;
                            }
                            if (x < 0 || x >= xColumn)
                            {
                                break;
                            }

                            if (sweets[x, matchLineSweets[i].Y].CanColor() && sweets[x, matchLineSweets[i].Y].ColoredComponent.Color == color)
                            {
                                matchRowSweets.Add(sweets[x, matchLineSweets[i].Y]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (matchRowSweets.Count < 2)
                    {
                        matchRowSweets.Clear();
                    }
                    else
                    {
                        for (int j = 0; j < matchRowSweets.Count; j++)
                        {
                            finishedMatchingSweets.Add(matchRowSweets[j]);
                        }
                        break;
                    }
                }
            }

            if (finishedMatchingSweets.Count >= 3)
            {
                return finishedMatchingSweets;
            }
        }

        return null;
    }

    //甜品清除方法
    public bool ClearSweet(int x, int y)
    {
        if (sweets[x, y].CanClear() && !sweets[x, y].ClearedComponent.IsClearing)
        {
            sweets[x, y].ClearedComponent.Clear();
            CreateNewSweet(x, y, SweetsType.EMPTY);

            return true;
        }
        return false;
    }

    //清除matchsweet表中的糖果
    private bool ClearAllMatchedSweet()
    {
        bool needRefill = false;//发生消除时值真，需要填充
        for (int y = 0; y < yRow; y++)
        {
            for (int x = 0; x < xColumn; x++)
            {
                if (sweets[x, y].CanClear())
                {
                    List<GameSweet> matchList = MatchSweets(sweets[x, y], x, y);
                    if (matchList != null)
                    {
                        for (int i = 0; i < matchList.Count; i++)
                        {
                            if (ClearSweet(matchList[i].X, matchList[i].Y))
                            {
                                needRefill = true;

                            }
                        }
                    }
                }
            }
        }
        return needRefill;
    }






    //鼠标获取对应甜品
    public void PressSweet(GameSweet sweet)
    {
        pressedSweet = sweet;
    }
    public void EnterSweet(GameSweet sweet)
    {
        enterSweet = sweet;
    }
    public void ReleaseSweet()
    {
        if (IsFriend(pressedSweet, enterSweet))
        {
            ExchangeSweets(pressedSweet, enterSweet);
        }

    }




    //甜品是否相邻的判断方法
    private bool IsFriend(GameSweet sweet1, GameSweet sweet2)
    {
        return (sweet1.X == sweet2.X && Mathf.Abs(sweet1.Y - sweet2.Y) == 1) || (sweet1.Y == sweet2.Y && Mathf.Abs(sweet1.X - sweet2.X) == 1);
    }

    //交换两个甜品的方法
    private void ExchangeSweets(GameSweet sweet1, GameSweet sweet2)
    {
        if (sweet1.CanMove() && sweet2.CanMove())
        {
            sweets[sweet1.X, sweet1.Y] = sweet2;
            sweets[sweet2.X, sweet2.Y] = sweet1;

            //存在可消除的甜品，位置交换
            if (MatchSweets(sweet1, sweet2.X, sweet2.Y) != null || MatchSweets(sweet2, sweet1.X, sweet1.Y) != null)
            {
                int tempX = sweet1.X;
                int tempY = sweet1.Y;

                sweet1.MovedComponent.Move(sweet2.X, sweet2.Y, fillTime);
                sweet2.MovedComponent.Move(tempX, tempY, fillTime);
                ClearAllMatchedSweet();
                StartCoroutine(AllFill());
                pressedSweet = null;
                enterSweet = null;
            }
            else//位置复原
            {
                sweets[sweet1.X, sweet1.Y] = sweet1;
                sweets[sweet2.X, sweet2.Y] = sweet2;
            }

        }
    }


    //全部填充的方法
    public IEnumerator AllFill()
    {
        bool needRefill = true;

        while (needRefill)
        {
            yield return new WaitForSeconds(fillTime);
            while (Fill())
            {
                yield return new WaitForSeconds(fillTime);
            }

            //清除所有我们已经匹配好的甜品
            needRefill = ClearAllMatchedSweet();
        }
    }
    //部分填充的方法
    public bool Fill()
    {
        bool filledNotFinished = false;//填充是否完成
        //非最上排的填充方法
        for (int y = yRow - 2; y >= 0; y--)
        {
            for (int x = 0; x < xColumn; x++)
            {
                GameSweet sweet = sweets[x, y];//得到当前甜品元素的位置
                if (sweet.CanMove())//如果该元素可以移动，则可以垂直填充
                {
                    GameSweet sweetBelow = sweets[x, y + 1];//找到下面一格的甜品
                    if (sweetBelow.Type == SweetsType.EMPTY)//如果为空
                    {
                        Destroy(sweetBelow.gameObject);
                        sweet.MovedComponent.Move(x, y + 1, fillTime);//向下移动
                        sweets[x, y + 1] = sweet;
                        CreateNewSweet(x, y, SweetsType.EMPTY);//把自身原来的位置为空
                        filledNotFinished = true;
                    }
                    else//斜向填充代码
                    {
                        for (int down = -1; down <= 1; down++)//-1↙，0↓，1↘
                        {
                            if (down != 0)//垂直填充代码在上方
                            {
                                int downX = x + down;

                                if (downX >= 0 && downX < xColumn) //排除最左和最右两列特殊情况
                                {
                                    GameSweet downSweet = sweets[downX, y + 1];//拿到左下方甜品
                                    if (downSweet.Type == SweetsType.EMPTY)
                                    {
                                        bool canfill = true;//用来判断垂直填充是否可以满足填充要求
                                        for (int aboveY = y; aboveY >= 0; aboveY--)
                                        {
                                            GameSweet sweetAbove = sweets[downX, aboveY];
                                            if (sweetAbove.CanMove())
                                            {
                                                break;
                                            }
                                            else if (!sweetAbove.CanMove() && sweetAbove.Type != SweetsType.EMPTY)
                                            {
                                                canfill = false;
                                                break;
                                            }
                                        }


                                        if (!canfill)
                                        {

                                            Destroy(downSweet.gameObject);
                                            sweet.MovedComponent.Move(downX, y + 1, fillTime);
                                            sweets[downX, y + 1] = sweet;//斜向填充
                                            CreateNewSweet(x, y, SweetsType.EMPTY);
                                            filledNotFinished = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        //最上排的特殊情况 在屏幕外的0行生成方块然后掉落
        for (int x = 0; x < xColumn; x++)
        {
            GameSweet sweet = sweets[x, 0];
            if (sweet.Type == SweetsType.EMPTY)
            {
                GameObject newSweet = Instantiate(sweetProfabDict[SweetsType.NORMAL], CorrectPosition(x, -1), Quaternion.identity);
                newSweet.transform.parent = transform;

                sweets[x, 0] = newSweet.GetComponent<GameSweet>();
                sweets[x, 0].Init(x, -1, this, SweetsType.NORMAL);
                sweets[x, 0].MovedComponent.Move(x, 0, fillTime);
                sweets[x, 0].ColoredComponent.SetColor((ColorSweet.ColorType)Random.Range(0, sweets[x, 0].ColoredComponent.NumColors));
                filledNotFinished = true;
            }
        }

        return filledNotFinished;
    }











    //创建甜品
    public GameSweet CreateNewSweet(int x, int y, SweetsType type)
    {
        GameObject newSweet = Instantiate(sweetProfabDict[type], CorrectPosition(x, y), Quaternion.identity);
        newSweet.transform.parent = transform;

        sweets[x, y] = newSweet.GetComponent<GameSweet>();
        sweets[x, y].Init(x, y, this, type);
        return sweets[x, y];

    }

    private void InitSweets()
    {
        sweets = new GameSweet[xColumn, yRow];
        for (int x = 0; x < xColumn; x++)
        {
            for (int y = 0; y < yRow; y++)
            {
                CreateNewSweet(x, y, SweetsType.EMPTY);

                //测试代码 生成
                //if (sweets[x,y].CanMove())
                //{
                //    sweets[x, y].MovedComponent.Move(x, y);
                //}


                // if (sweets[x, y].CanColor())
                // {
                //    sweets[x, y].ColoredComponent.SetColor((ColorSweet.ColorType)Random.Range(0,sweets[x,y].ColoredComponent.NumColors));//随机数转颜色枚举
                // }




            }
        }
        //测试代码 饼干
        Destroy(sweets[4, 4].gameObject);
        CreateNewSweet(4, 4, SweetsType.BARRIER);


    }

    private void InitDictionary()//字典实例化
    {
        sweetProfabDict = new Dictionary<SweetsType, GameObject>();
        for (int i = 0; i < sweetPrefabs.Length; i++)
        {
            if (!sweetProfabDict.ContainsKey(sweetPrefabs[i].type))
            {
                sweetProfabDict.Add(sweetPrefabs[i].type, sweetPrefabs[i].prefab);
            }

        }
    }

    private void InitColumAndRow()//初始化背景网格
    {
        for (int x = 0; x < xColumn; x++)
        {
            for (int y = 0; y < yRow; y++)
            {
                GameObject chocolate = Instantiate(gridPrefab, CorrectPosition(x, y), Quaternion.identity);
                chocolate.transform.SetParent(transform);
            }
        }
    }

    public Vector3 CorrectPosition(int x, int y)
    {
        //（0.45，-0.5，0）
        // 实际需要实例化的位置 = gamemanager位置坐标 + 大网格长度 / 高度的一半 + 行列对应的xy坐标
        return new Vector3(transform.position.x - xColumn / 2f + x, transform.position.y + yRow / 2f - y);
    }


    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitColumAndRow();
        InitDictionary();
        InitSweets();
        StartCoroutine(AllFill());
    }

    // Update is called once per frame
    void Update()
    {
        GameTimeandscore();
    }
}
