using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : WeaponController
{

    // shar
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpear = Instantiate(weaponData.Prefab);
        spawnedSpear.transform.position = transform.position;
        spawnedSpear.GetComponent<SpearBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}
