using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : WeaponController
{
    // shar
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedArrow = Instantiate(weaponData.Prefab);
        spawnedArrow.transform.position = transform.position;
        spawnedArrow.GetComponent<ArrowBehaviour>().DirectionChecker2(pm.lastMovedVector);
    }
}
