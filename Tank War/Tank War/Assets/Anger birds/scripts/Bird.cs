using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isClick = false;
    private Vector3 lastPos;
    private bool isFly = false;
    private bool isUsedSkill = false;
    


    [HideInInspector]//隐藏标签
    public SpringJoint2D sp;//松手时让组件失活
    protected Rigidbody2D rg;
 
    public Transform rightPos;
    public float maxDis = 0.8f;
    public LineRenderer right;//右划线
    public LineRenderer left;//左划线
    public Transform rightLine;
    public Transform leftLine;
    public GameObject boom;
    public static birdManager _birdinstance;
    public bool canMove = true;
    public bool isblack = false;

    public AudioClip select;
    public AudioClip fly;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isblack)
        {
            isUsedSkill = false;
        }
    }

    public void SkillUseCheak()
    {
         if(isFly)
        {
            if(isUsedSkill)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    ShowSkill();
                }          
            }
        }
    }

    public virtual void  ShowSkill()
    {
        isUsedSkill = false;
    }

    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    private void Line()//划线函数
    {
        right.SetPosition(0, rightLine.position);
        right.SetPosition(1, transform.position);
        left.SetPosition(0, leftLine.position);
        left.SetPosition(1, transform.position);

    }

    private void Speed()
    {
        if(isFly)
        {
            if (lastPos == this.transform.position)
            {
                Next();
            }
        }
        lastPos = this.transform.position;
    }
    private void Fly()
    {
        AudioPlay(fly);
        sp.enabled = false;
        isFly = true;
        isUsedSkill = true;
    }

    private void Next()
    {
        birdManager._birdinstance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        birdManager._birdinstance.NextBird();
        

    }
    private void OnMouseDown()//鼠标按下
    {
        if (canMove)
        {
            AudioPlay(select);
            isClick = true;
        }
    }
     
    private void OnMouseUp()//鼠标松开
    {
        if (canMove)
        {
            isClick = false;
            Invoke("Fly", 0.1f);
            right.enabled = false;
            left.enabled = false;
            canMove = false;
        }

    }


    private void MouseFollow()//小鸟的鼠标跟随

    {
        
        if (isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position -= new Vector3(0, 0, Camera.main.transform.position.z);//2D摄像机的Z轴坐标为-4，因此需要一个坐标处理的转换 
            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;//单位化向量
                pos *= maxDis;//最大长度的向量
                transform.position = pos + rightPos.position;
            }

        }
    }

    private void CamaraFollow()//摄像机跟随
    {
        float amooth = 6;
        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Mathf.Clamp(posX, 0, 80),Camera.main .transform .position .y , Camera.main.transform.position.z),
            amooth*Time .deltaTime);
    }


    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        lastPos = this.transform.position;
        right.enabled = true;
        left.enabled = true;
        InvokeRepeating("Speed", 1, 0.1f);  
    }
    // Update is called once per frame
    private void Update()
    {
        if (isClick)
        {
            MouseFollow();
        }
        CamaraFollow();
        SkillUseCheak();
    }
    private  void FixedUpdate()
    {
        Line();
    }
}
