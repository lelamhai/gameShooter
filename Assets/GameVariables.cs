using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables {

    private static GameVariables instanceH;
    private GameVariables() { }

    public int coundBullet;

    private int bullet;

    public int Bullet
    {
        get
        {
            return bullet;
        }

        set
        {
            if(value < coundBullet)
            {
                bullet = value;
            }
        }
    }


    public static GameVariables InstanceH
    {
        get
        {
            if (instanceH == null)
            {
                instanceH = new GameVariables();
            }
            return instanceH;
        }
    }
}
