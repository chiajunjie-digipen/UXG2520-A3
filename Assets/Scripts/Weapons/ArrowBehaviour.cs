using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : ProjectileWeaponBehaviour
{
    ArrowController ac;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ac = FindObjectOfType<ArrowController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * ac.speed * Time.deltaTime;
    }
}
