using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public float[] position;

    public GameData (Ball ball)
    {
        score = ball.Score;


        position = new float[2];
        position[0] = ball.player.transform.position.x;
        position[1] = ball.player.transform.position.y;
        //position[3] = ball.player.transform.position.z;

    }

}
