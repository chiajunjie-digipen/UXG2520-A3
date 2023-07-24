using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) //shar
    {
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
            //if GO has icollectible inteface, call collect
        }
    }
}
