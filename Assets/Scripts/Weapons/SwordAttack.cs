using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpear = Instantiate(prefab);
        spawnedSpear.transform.position = transform.position;
    }

}
