using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : ProjectileWeaponBehaviour
{
    SwordController swc;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        swc = FindObjectOfType<SwordController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * swc.speed * Time.deltaTime;
    }
}
