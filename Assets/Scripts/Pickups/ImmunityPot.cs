using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunityPot : MonoBehaviour, ICollectible
{
    //public float invincibilityDuration; //shar
    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.Invincible(float.Parse(FindObjectOfType<MultiplierHandler>().multiplierProperties[player.currentLevel]["strengthenDuration"]));
        //use strengthen duration for invincibility
        Destroy(gameObject);
    }
}
