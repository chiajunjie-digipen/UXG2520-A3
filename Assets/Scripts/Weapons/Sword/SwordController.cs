using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : WeaponController //shar
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedSword = Instantiate(weaponData.Prefab);
        spawnedSword.transform.position = transform.position;
        spawnedSword.GetComponent<SwordBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}
