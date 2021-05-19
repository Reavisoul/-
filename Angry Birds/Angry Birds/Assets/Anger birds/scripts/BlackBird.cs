using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    private  List<GameObject> blocks = new List<GameObject>();
    private float boomDistense;
    private Pig pig;

    private void Boom()
    {
        foreach (GameObject enemy in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            boomDistense = Vector3.Distance(this.transform.position, enemy.transform.position);
            print(boomDistense);
            if (enemy.tag == "Enemy" && boomDistense < 1)
            {
                blocks.Add(enemy);
            }
        }
        for (int i = 0; i < blocks.Count; i++)
        {
            pig = blocks[i].GetComponent<Pig>();
            pig.Dead();
        }
        birdManager._birdinstance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        birdManager._birdinstance.NextBird();
    }
    public override void ShowSkill()
    {
        base.ShowSkill();
        Boom();
    }

}


