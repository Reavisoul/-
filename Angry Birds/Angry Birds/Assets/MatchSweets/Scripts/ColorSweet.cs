using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSweet: MonoBehaviour
{
    //糖果种类
    public enum ColorType
    {
        YELLOW,
        PURPLE,
        RED,
        BLUE,
        GREEN,
        PINK,
        ANY,
        COUNT
    }
    //定义糖果种类的结构体枚举调用字典
    [System.Serializable]
    public struct ColorSprite
    {
        public ColorType color;
        public Sprite sprite;
    }
    public ColorSprite[] ColorSprites;
    private Dictionary<ColorType, Sprite> colorSpriteDict;//颜色对应不同的精灵图片 渲染
    private SpriteRenderer sprite;
    private ColorType color;
    
  //接口  

    //我们所拥有的颜色数量
    public int NumColors
    {
        get { return ColorSprites.Length; }
    }

    public ColorType Color { get => color; set => SetColor(value); }
    //


    public void SetColor(ColorType newColor)
    {
        color = newColor;
        if(colorSpriteDict .ContainsKey(newColor))
        {
            sprite.sprite = colorSpriteDict[newColor];
        }
    
    
    }




    private void Init()
    {
        sprite = transform.Find("Sweet").GetComponent<SpriteRenderer>();
        colorSpriteDict = new Dictionary<ColorType, Sprite>();//实例化字典和获取组件
        for(int i=0;i<ColorSprites.Length;i++)
        {
            if(!colorSpriteDict.ContainsKey(ColorSprites[i].color))
            {
                colorSpriteDict.Add(ColorSprites[i].color, ColorSprites[i].sprite);
            }
        }
    }

    private void Awake()
    {
        Init();
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
