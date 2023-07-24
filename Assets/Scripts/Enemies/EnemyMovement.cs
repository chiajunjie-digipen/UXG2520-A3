using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour //shar
{
    public EnemyStats enemyData;
    public int enemyId;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        enemyData = GetComponent<EnemyStats>();
        enemyId = enemyData.enemyId;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.currentMoveSpeed * Time.deltaTime); //makes enemy track and move towards player
    }
}
