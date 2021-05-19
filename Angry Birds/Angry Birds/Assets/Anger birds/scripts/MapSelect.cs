using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    private bool isSelect = false;
    public int levelcount=0;

    public GameObject locks;
    public GameObject panel;
    public GameObject map;

    public void Selected()
    {
        if(isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);

        }
    }
    public void panelSelect()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("totalLevel") >= levelcount)
        {
            isSelect = true;
        }
        if (isSelect)
        {
            locks.SetActive(false);
        }
    }
}
