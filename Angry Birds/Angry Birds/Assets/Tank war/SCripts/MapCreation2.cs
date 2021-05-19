using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation2 : MonoBehaviour
{
    //装饰初始化地图所需物体的数组
    //0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙 
    public GameObject[] item;

    //已经有东西的位置列表
    public List<Vector3> itemPositionList = new List<Vector3>();

    //物体生成函数
    private void CreateItem(GameObject createCameObject, Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createCameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    //产生随机位置的方法
    private Vector3 CreateRandomPisition()
    {
        //不生成边界的两列两行
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 7), 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }
        }
    }

    //用来判断位置是否重复
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }


    //后续产生敌人
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        if (num == 0)
        {
            CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        }
        else if (num == 1)
        {
            CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        }
        else if (num == 2)
        {
            CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);
        }
    }



    private void InitMap()
    {
        //老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //用墙把老家围起来
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        //用空气墙把地图围起来
        for (int i = -9; i < 10; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int j = -11; j < 12; j++)
        {
            CreateItem(item[6], new Vector3(j, -9, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(j, 9, 0), Quaternion.identity);
        }
        //出生点
        GameObject player1 = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        player1.GetComponent<Born>().createPlayer = true;
        //产生敌人
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 4, 5);


        //建造地图的其他物品
        //墙
        for (int i = 0; i < 60; i++)
        {
            CreateItem(item[1], CreateRandomPisition(), Quaternion.identity);
        }
        //障碍
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPisition(), Quaternion.identity);
        }
        //河流
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPisition(), Quaternion.identity);
        }
        //草
        for (int i = 0; i < 40; i++)
        {
            CreateItem(item[5], CreateRandomPisition(), Quaternion.identity);
        }
    }

    private void Awake()
    {
        InitMap();
    }
}
