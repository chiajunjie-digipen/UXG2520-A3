using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObj enemyData; //shar

    //current stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentDamage;
    public int enemyId;
    List<string> properties = new List<string>();

    private string data = ""; //jj
    public Dictionary<int, Dictionary<string, float>> enemyProperties = new Dictionary<int, Dictionary<string, float>>();
    public int XPdrop;

    public float despawnDistance = 20f; //shar
    Transform player;

    void Awake() //jj
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

    void Start() //shar
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

    public void Kill() //jj
    {
        PlayerStats player = GameObject.Find("Player").GetComponent<PlayerStats>();
        player.XpUp(XPdrop);
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col) //shar
    {
        PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
        player.TakeDamage(currentDamage);
    }

    private void OnDestroy()
    {
        if(FindObjectOfType<EnemySpawner>() && FindObjectOfType<AnalyticsTracker>()) {
            GameObject.FindObjectOfType<AnalyticsTracker>().enemiesKilled++;
            EnemySpawner es = FindObjectOfType<EnemySpawner>();
            es.OnEnemyKilled();
        }
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}
