using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCapacity : MonoBehaviour {

    private static float speed = 0;
    public static float SpeedEnemy
    {
        get { return speed; }
        set { speed = value; }
    }
}
