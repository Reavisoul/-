using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(Resources.Load("level"+PlayerPrefs.GetInt("nowLevel")));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
