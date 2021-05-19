using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite BrokenSprite;
    public GameObject explosionPrefab;
    public AudioClip dieAudio;


    private int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;

    }
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
        int temp = GetScene();

        if (temp == 2)
        {
            PlayManager1.Instance.lifeValue1 = 0;
            PlayManager1.Instance.isDead1 = true;
            PlayManager1.Instance.lifeValue2 = 0;
            PlayManager1.Instance.isDead2 = true;
        }
        else
        {
            PlayManager.Instance.lifeValue = 0;
            PlayManager.Instance.isDead = true;

        }
    }
}
