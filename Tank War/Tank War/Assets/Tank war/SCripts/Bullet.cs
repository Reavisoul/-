using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{ 
    public float moveSpeed = 10;//子弹速度
    public bool isPlayerBullect;//决定子弹属性
    public AudioClip BarrierAudio;//引用子弹音频

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime,Space.World);
    }

    //碰撞触发检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullect)
                {
                    collision.SendMessage("Die");                
                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(BarrierAudio, transform.position);
                break;
            case "Barrier":
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(BarrierAudio, transform.position);
                break;
            case "AirBarrier":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }




}

