using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedOrb = Instantiate(weaponData.prefab);
        spawnedOrb.transform.position = transform.position;
        spawnedOrb.transform.parent = transform; // orb spawns below player and follows them around
    }
}
