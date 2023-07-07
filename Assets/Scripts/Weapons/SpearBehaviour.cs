using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : ProjectileWeaponBehaviour
{
    SpearController sc;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        sc = FindObjectOfType<SpearController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * sc.speed * Time.deltaTime;
    }
}
