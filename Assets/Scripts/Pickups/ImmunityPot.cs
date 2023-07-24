using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunityPot : MonoBehaviour, ICollectible
{
    public float invincibilityDuration; //shar
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.Invincible(invincibilityDuration);
        Destroy(gameObject);
    }
}
