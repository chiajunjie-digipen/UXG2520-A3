using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSpear = Instantiate(weaponData.prefab);
        spawnedSpear.transform.position = transform.position;
        spawnedSpear.GetComponent<SpearBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}
