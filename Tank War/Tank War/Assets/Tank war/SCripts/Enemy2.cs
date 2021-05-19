using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 3;
    private SpriteRenderer sr;//位移图片选择值
    public Sprite[] tankSprite;
    public GameObject BulletPrefab;//子弹
    private Vector3 BulletEulerAngles;//子弹角度
    private float timeVal;//攻击间隔定时器
    public GameObject explosionPrefab;//爆炸
    private float timeValChangeDirection = 5;//转弯计时器
    private float v;
    private float h;

    //移动方法
    private void Move()
    {
        int num = Random.Range(1, 5);
        if (timeValChangeDirection >= num)
        {
            int Turn = Random.Range(0, 11);
            if (Turn > 6)
            {
                v = -1;
                h = 0;
            }
            else if (Turn == 0)
            {
                v = 1;
                h = 0;
            }
            else if (Turn > 0 && Turn <= 3)
            {
                h = -1;
                v = 0;
            }
            else if (Turn > 3 && Turn <= 6)
            {
                h = 1;
                v = 0;
            }
            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
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

    //碰撞转换方向
    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            timeValChangeDirection = 5;
        }
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
        Instantiate(BulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
        timeVal = 0;

    }

    //死亡方法
    private void Die()
    {
        int temp = GetScene();

        if (temp == 2)
        {
            PlayManager1.Instance.playerScore++;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            PlayManager.Instance.playerScore++;
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
    private int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;

    }


    // Update is called once per frame
    void Update()
    {
        //攻击计时器
        int num = Random.Range(1, 3);
        if (timeVal >= num)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        Move();
    }
}
