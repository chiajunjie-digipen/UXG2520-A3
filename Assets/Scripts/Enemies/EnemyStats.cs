using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObj enemyData;

    //current stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentDamage;
    public int enemyId;
    List<string> properties = new List<string>();

    private string data = "";
    public Dictionary<int, Dictionary<string, float>> enemyProperties = new Dictionary<int, Dictionary<string, float>>();
    public int XPdrop;

    public float despawnDistance = 20f;
    Transform player;

    void Awake()
    {
        /*currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;*/

        enemyId = enemyData.enemyid;

        StreamReader reader = new StreamReader("Assets/CSVs/enemyStats.csv");
        properties = new List<string>(reader.ReadLine().Split(','));

        data = reader.ReadLine();
        while (data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            enemyProperties.Add(int.Parse(dataList[0]), new Dictionary<string, float>());
            int counter = 0;
            foreach (string property in properties) {
                enemyProperties[int.Parse(dataList[0])].Add(property, float.Parse(dataList[counter]));
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close();

        //Assigns Enemy Stats
        currentMoveSpeed = enemyProperties[enemyId]["enemyMoveSpd"];
        currentHealth = enemyProperties[enemyId]["enemyHP"];
        currentDamage = enemyProperties[enemyId]["enemyAtk"];
        XPdrop = (int)enemyProperties[enemyId]["XPdrop"]; // i did a wucky mucky and declared all of these mfs floats and so now i atone for my mistake



    }

    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            //if (gameObject != null)
            //{
            //    Kill();
            //}
            Kill();
        }
    }

    public void Kill()
    {
        PlayerStats player = GameObject.Find("Player").GetComponent<PlayerStats>();
        player.XpUp(XPdrop);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
        player.TakeDamage(currentDamage);
    }

    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        GameObject.FindObjectOfType<AnalyticsTracker>().enemiesKilled++;
        es.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}
