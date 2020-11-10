using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePoints : MonoBehaviour
{
 
    
    void OnCollisionEnter(Collision collision)
    {
        //when the robot/player hits a coin/sphere at 50 to score and 1 to items collected
        if(collision.transform.name == "Robot")
        {
            KeepScoreScene3.items += 1;
            KeepScoreScene3.itemsLeft -= 1;
            KeepScoreScene3.Score += 25;
            //Debug.Log("HIT BALL");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
