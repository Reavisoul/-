using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    private SpriteRenderer render;
    public float maxSpeed = 10;
    public float minSpeed = 5;
    public Sprite hurt;//受伤图片引用
    public GameObject boom;//爆炸特效
    public bool isPig = false;
    public static birdManager _birdinstance;

    public AudioClip audioHurt;
    public AudioClip dead;
    public AudioClip birdCollision;


    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    public void Dead()
    { 
        if(isPig)
        {
            birdManager._birdinstance.pigs.Remove(this);
            AudioPlay(dead);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject .tag =="player")
        {
            AudioPlay(birdCollision);
        }
        if (collision.relativeVelocity.magnitude > maxSpeed)//碰撞时的相对速度>10直接死亡
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
            AudioPlay(audioHurt);
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
