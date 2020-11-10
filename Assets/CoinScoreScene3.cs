using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScoreScene3 : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        //when the robot/player hits a coin/sphere at 50 to score and 1 to items collected
        if (collision.transform.name == "Robot")
        {
            KeepScore.items += 1;

            KeepScore.Score += 25;
            //Debug.Log("HIT BALL");
            Destroy(gameObject);
        }
    }
}
