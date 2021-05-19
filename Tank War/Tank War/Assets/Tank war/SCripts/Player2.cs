using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 3;
    public int hlock, vlock;//位移改善键值
    private SpriteRenderer sr;//位移图片选择值
    public Sprite[] tankSprite;
    public GameObject BulletPrefab;//子弹
    private Vector3 BulletEulerAngles;//子弹角度
    private float timeVal;//攻击间隔定时器
    public GameObject explosionPrefab;//爆炸
    private bool isDefended = true;//无敌状态
    private float defendTimVal = 3;//无敌计时器
    public GameObject defendEffectPrefab;//无敌
    public bool isDefeat;
    //移动方法
    private void Move()
    {
        float h = Input.GetAxisRaw("player2Horizontal");
        float v = Input.GetAxisRaw("player2Vertical");


        if (h == 0 && v == 0)
        {
            hlock = 0;
            vlock = 0;
        }
        if (h != 0 && v == 0)
        {
            hlock = 2;
            vlock = 1;
        }
        if (h == 0 && v != 0)
        {
            hlock = 1;
            vlock = 2;
        }
        if (h != 0 && v != 0)
        {

            if (hlock * vlock == 0)
            {
                v = 0;
            }
            else if (hlock > vlock)
            {
                h = 0;
            }
            else if (hlock < vlock)
            {
                v = 0;
            }
        }
        if (h > 0)
        {
            sr.sprite = tankSprite[1];
            BulletEulerAngles = new Vector3(0, 0, -90);
        }
        else if (h < 0)
        {
            sr.sprite = tankSprite[3];
            BulletEulerAngles = new Vector3(0, 0, 90);
        }

        if (v > 0)
        {
            sr.sprite = tankSprite[0];
            BulletEulerAngles = new Vector3(0, 0, 0);
        }
        else if (v < 0)
        {
            sr.sprite = tankSprite[2];
            BulletEulerAngles = new Vector3(0, 0, 180);
        }
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
    }

    private int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;

    }
    //移动方向贴图调整
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    //攻击方法
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
            timeVal = 0;
        }

    }

    //死亡方法 
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
        int temp = GetScene();

        if (temp == 2)
        {
            PlayManager1.Instance.isDead2 = true;
        }
        else
        {
            PlayManager.Instance.isDead = true;

        }
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        //攻击计时器
        if (timeVal >= 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }

        //无敌计时器
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimVal -= Time.deltaTime;
            if (defendTimVal <= 0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}


