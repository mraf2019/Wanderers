using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constanat : MonoBehaviour
{
    public const float refreshInterval = 2 * 60f;  // 2 min
    public static float[,] positions =
    {
        {18,34 },
        {32,-10 },
        {-30,10 },
        {-20,-33 },
        {-66,-7 },
        {-53,24 },
        {37,-58 },
        {-12,-75 },
        {-70,-75 }
    };

    public static Vector3[] LootPos = new Vector3[15]
    {
        new Vector3(51,37,0),
        new Vector3(19,34,0),
        new Vector3(-13,50,0),
        new Vector3(-46,34,0),
        new Vector3(-58,53,0),
        new Vector3(-46,-3,0),
        new Vector3(-2,15,0),
        new Vector3(19,-10,0),
        new Vector3(51,-14,0),
        new Vector3(41,-43,0),
        new Vector3(55,-62,0),
        new Vector3(-4,-33,0),
        new Vector3(-15,-52,0),
        new Vector3(-41,-39,0),
        new Vector3(-55,-65,0)
    };
}
