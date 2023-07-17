using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.ChangeHealth(-40);
        }
    }

}
