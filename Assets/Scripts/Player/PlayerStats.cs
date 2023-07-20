using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{

    //current stats
    [SerializeField] float currentHealth;
    [SerializeField] float currentRecovery;
    public float currentMoveSpeed;

    //THE PART WITH LEVELS BABYYYYY
    [SerializeField] int xp;
    [SerializeField] int currentXPThreshold;
    [SerializeField] int currentLevel;

    [SerializeField] float maxHealth;

    private string data = "";
    public Dictionary<int, Dictionary<string, string>> playerProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();
    private void Awake()
    {
        StreamReader reader = new StreamReader("Assets/CSVs/levels.csv");
        properties = new List<string>(reader.ReadLine().Split(','));
        

        data = reader.ReadLine();
        
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            playerProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                playerProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
                Debug.Log(property + " " + dataList[counter]);
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close();

        currentLevel = 1;

        //levels start at 1
        currentHealth = float.Parse(playerProperties[1]["playerHP"]);
        

        //maxHealth set
        maxHealth = float.Parse(playerProperties[1]["playerHP"]);

        currentRecovery = float.Parse(playerProperties[1]["recovery"]);

        currentMoveSpeed = float.Parse(playerProperties[1]["playerMoveSpd"]);

        //level is set for next
        currentXPThreshold = int.Parse(playerProperties[2]["expRequired"]);

    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
        
    }

    public void Kill()
    {
        Debug.Log("Game Over");
    }

    //Iframes
    [Header("I Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    public void RestoreHealth (float amount)
    {
        // heal when hp is less than max hp
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;

            if (currentHealth > maxHealth) // makes sure player hp does not exceed max hp
            {
                currentHealth = maxHealth;
            }
        }


    }

    public void XpUp (int amount) { // doubles as level up code
        xp += amount;
        if (xp >= currentXPThreshold) {
            currentLevel += 1;
            xp = 0;
            currentXPThreshold = int.Parse(playerProperties[currentLevel+1]["expRequired"]);

            maxHealth = float.Parse(playerProperties[currentLevel+1]["playerHP"]);

            currentRecovery = float.Parse(playerProperties[currentLevel]["recovery"]);

            currentMoveSpeed = float.Parse(playerProperties[currentLevel]["playerMoveSpd"]);
        }
    }

    public void Invincible(float duration)
    {
        if (!isInvincible) //if not invincible, make invincible and set timer to duration
        {
            isInvincible = true;
            invincibilityTimer = duration;

            if (invincibilityTimer > 0) //timer countdown for invincibility
            {
                invincibilityTimer -= Time.deltaTime;
            }
            else if (isInvincible)
            {
                isInvincible = false;
            }
        }
    }
}
