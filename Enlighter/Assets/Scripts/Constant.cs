using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constanat : MonoBehaviour
{
    public const float refreshInterval = 2 * 30f;  // 2 min
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

    public static List<CardInfo> cardList = new List<CardInfo>
    {
        new CardInfo
        {
            name ="Sharp_Stone",
            id = 1,
            attack = true,
            healthChange = 5,
            speedChange = 0,
            money = 30,
            invincible = false,
            price = 150
        },
        new CardInfo
        {
            name ="Broken_Dagger",
            id = 2,
            attack = true,
            healthChange = 10,
            speedChange = 0,
            money = 25,
            invincible = false,
            price = 250
        },
        new CardInfo
        {
            name ="Expired_Energy_Drink",
            id = 3,
            attack = true,
            healthChange = 15,
            speedChange = 0,
            money = 20,
            invincible = false,
            price = 150
        },
        new CardInfo
        {
            name ="Mobius_Blade",
            id = 4,
            attack = true,
            healthChange = 30,
            speedChange = 0,
            money = 5,
            invincible = false,
            price = 300
        },
        new CardInfo
        {
            name ="Jar_of_Compressed_Ether",
            id = 5,
            attack = true,
            healthChange = 35,
            speedChange = 0,
            money = 0,
            invincible = false,
            price = 350
        },
        new CardInfo
        {
            name ="Magic_Book_with_Blurred_Cover",
            id = 6,
            attack = true,
            healthChange = 15,
            speedChange = -0.3f,
            money = 10,
            invincible = false,
            price = 450
        },
        new CardInfo
        {
            name ="Promised_Land",
            id = 7,
            attack = false,
            healthChange = 0,
            speedChange = 0.1f,
            money = 0,
            invincible = true,
            price = 700
        },
        new CardInfo
        {
            name ="Gods_Punishment",
            id = 8,
            attack = true,
            healthChange = 25,
            speedChange = -0.5f,
            money = 0,
            invincible = false,
            price = 600
        },
        new CardInfo
        {
            name ="Lay_on_Hands",
            id = 9,
            attack = false,
            healthChange = 25,
            speedChange = 0,
            money = 5,
            invincible = false,
            price = 400
        },
        new CardInfo
        {
            name ="Holy_Blessing",
            id = 10,
            attack = false,
            healthChange = 0,
            speedChange = 0.8f,
            money = 0,
            invincible = false,
            price = 400
        },
        new CardInfo
        {
            name ="Dream_of_Enlightenment",
            id = 11,
            attack = false,
            healthChange = 30,
            speedChange = 0,
            money = 20,
            invincible = false,
            price = 500
        }
    };
}
