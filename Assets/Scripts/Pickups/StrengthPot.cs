using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPot : MonoBehaviour, ICollectible
{
    public void Collect()
    {
        MultiplierHandler multiplier = FindObjectOfType<MultiplierHandler>();
        Destroy(gameObject);
    }
}
