using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject playerPrefab;//玩家
    public GameObject[] enemyPrefabList;//敌人
    public bool createPlayer;//决定创建物

    // Start is called before the first frame update
    void Start()
    {   
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void BornTank()
    {
        if (createPlayer)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else 
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }
    }
}
