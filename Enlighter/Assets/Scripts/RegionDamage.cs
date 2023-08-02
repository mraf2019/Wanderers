using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionDamage : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        OnlinePlayer controller = other.GetComponent<OnlinePlayer>();

        if (controller != null)
        {
            if (controller.isInvincible)
            {
                return;
            }
            controller.ChangeHealth(-30, true);
        }
    }
}
