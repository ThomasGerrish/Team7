using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
    GameObject Player;
    float moveTimerSet = 0.554f;
    float moveTimer;
    float moveDirection = 1;
    float horizontalDistance = 0.1075f, verticalDistance = 0.355f;
    bool turning;
    float movesDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Move in intervals of 0.1075 every 0.554 seconds
        moveTimer = moveTimerSet;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            if (turning)
            {
                moveTimer += moveTimerSet;
                turning = false;
                movesDown++;
                if (movesDown <= 10) Player.GetComponent<PlayerScript>().GameOver();
                transform.Translate(0, -verticalDistance, 0);
            }
            else
            {
                moveTimer += moveTimerSet;
                transform.Translate(horizontalDistance * moveDirection, 0, 0);
            }
        }
    }

    public void Turn()
    {
        moveDirection *= -1;
        turning = true;
    }
}
