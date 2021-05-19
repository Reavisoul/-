using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedSweet : MonoBehaviour
{

    public AnimationClip clearAnimation;
    public bool IsClearing { get => isClearing; }
    
    
    private bool isClearing;
    protected GameSweet sweet;
    public AudioClip destoryAudio;


    public virtual void Clear()
    {
        isClearing = true;
            StartCoroutine(Clearcoroutine());
    }

    private IEnumerator Clearcoroutine()
    {
        Animator animator = GetComponent<Animator>();
        if(animator!=null)
        {
            animator.Play(clearAnimation.name);
            GameManager.Instance.playerScore += 10;
            AudioSource.PlayClipAtPoint(destoryAudio, transform.position);
            yield return new WaitForSeconds(clearAnimation.length);
            Destroy(gameObject);

        }

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
