using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSweet : MonoBehaviour
{
    public int X { get => x; set{ if (CanMove()) { x = value; } } }
    public int Y { get => y; set { if (CanMove()) { y = value; } } }
    public GameManager.SweetsType Type { get => type;}
    public MovedSweet MovedComponent { get => movedComponent;  }
    public ColorSweet ColoredComponent { get => coloredComponent; }
    public ClearedSweet ClearedComponent { get => clearedComponent; }

    private int x;

    private int y;

    private GameManager.SweetsType type;

    [HideInInspector]
    public GameManager gameManager;


    private MovedSweet movedComponent;
    private ColorSweet coloredComponent;
    private ClearedSweet clearedComponent;


    public bool CanClear()
    {
        return clearedComponent != null;
    }


    public bool CanColor()
    {
        return coloredComponent != null;
    }
    //判断糖果是否可以移动
    public bool CanMove()
    {
        return movedComponent != null;//moveConponent为空则不可移动
    }




    public void Init(int _x,int _y,GameManager _gameManager,GameManager.SweetsType _type)
    {
        x = _x;
        y = _y;
        gameManager = _gameManager;
        type = _type;
    }

    private void OnMouseEnter()
    {
        gameManager.EnterSweet(this);
    }
    private void OnMouseDown()
    {
        gameManager.PressSweet(this);
    }
    private void OnMouseUp()
    {
        gameManager.ReleaseSweet();
    }



    private void Awake()
    {
        movedComponent = GetComponent<MovedSweet>();//获取身上的移动脚本
        coloredComponent = GetComponent<ColorSweet>();
        clearedComponent = GetComponent<ClearedSweet>();
        
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
