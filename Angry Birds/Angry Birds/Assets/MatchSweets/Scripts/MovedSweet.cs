using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//控制糖果移动
public class MovedSweet : MonoBehaviour
{
    private GameSweet sweet;
    private IEnumerator moveCoroutine;//这样得到其他指令的时候我们可以终止协程



    //负责协程的开启与关闭
    public void Move(int newX, int newY,float time)
    {
        if (moveCoroutine != null)//如果身上有协程，则停止并开启一个新移动协程
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = MoveCoroutine(newX, newY, time);
        StartCoroutine(moveCoroutine);
    }

    //负责移动的协程
    private IEnumerator MoveCoroutine(int newX, int newY, float time)
    {
        sweet.X = newX;
        sweet.Y = newY;
        //每一帧移动一点点
        Vector3 startPos = transform.position;
        Vector3 endPos = sweet.gameManager.CorrectPosition(newX, newY);
        for (float t = 0; t < time; t+=Time.deltaTime) 
        {
            sweet.transform.position = Vector3.Lerp(startPos, endPos, t / time);
            yield return 0;
        }
        //防止未移动到位
        sweet.transform.position = endPos;
    }

    private void Awake()
    {
        sweet = GetComponent<GameSweet>();//得到本身的另一个脚本
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
