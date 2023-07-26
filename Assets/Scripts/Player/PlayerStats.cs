using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class PlayerStats : MonoBehaviour //shar and jj
{

    //current stats //shar
    public float currentHealth;
    [SerializeField] float currentRecovery;
    public float currentMoveSpeed;

    //THE PART WITH LEVELS BABYYYYY //jj
    [SerializeField] int xp;
    [SerializeField] int totalXpWithoutLevelReset;
    [SerializeField] int currentXPThreshold;
    public int currentLevel;

    public float maxHealth;

    private string data = "";
    public Dictionary<int, Dictionary<string, string>> playerProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();
    [SerializeField] bool gameOver;
    [SerializeField] List<GameObject> weapons;
    public int weaponUsed;

    private void Awake() //jj
    {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/CSVs/levels.csv");
        properties = new List<string>(reader.ReadLine().Split(','));
        

        data = reader.ReadLine();
        
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            playerProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                playerProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
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
        
        weaponUsed = Random.Range(0,4);
        GameObject.FindObjectOfType<AnalyticsTracker>().weaponUsed = weaponUsed + 1; // weapon assigned to list weapons is weaponId - 1 so +1 is used to offset for csv purposes
        weapons[weaponUsed].gameObject.SetActive(true);
    }

    void Update()
    {
        if (invincibilityTimer > 0) //timer for invincibility //shar
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }

        if (strengthenTimer > 0) //timer countdown for strengthening //jj
        {
            strengthenTimer -= Time.deltaTime;
        }
        else if (isStrengthened)
        {
            isStrengthened = false;
        }

    }

    void Start()
    {
        UpdateLevelText();
    }

    public void TakeDamage(float dmg) //how the player gets beat up //shar
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

    public void Kill() //jj
    {
        if(!gameOver){
            AnalyticsTracker at = GameObject.FindObjectOfType<AnalyticsTracker>();
            at.xpGained = totalXpWithoutLevelReset;
            at.counting = false;
            at.WriteData();
            Debug.Log("Game Over");
            gameOver = true;
            if(currentLevel > 3) {
                FindObjectOfType<SceneController>().SceneChange("Good End");
            } else {
                FindObjectOfType<SceneController>().SceneChange("Bad End");
            }
        }

    }

    //Iframes
    [Header("I Frames")] //shar
    public float invincibilityDuration;
    public float invincibilityTimer;
    public bool isInvincible;

    [Header("Strengthening")] //jj
    public float strengthenDuration;
    [SerializeField] public float strengthenTimer;
    public bool isStrengthened;

    [Header("UI")]
    public TMP_Text levelText;
    

    public void RestoreHealth (float amount) //for hp pot //shar
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

    public void XpUp (int amount) { // doubles as level up code //jj
        xp += amount;
        totalXpWithoutLevelReset += amount; // whole new variable so i dont need to calculate whenever xp resets to zero. my life is a joke
        if (xp >= currentXPThreshold) {
            currentLevel += 1;
            xp = 0;
            currentXPThreshold = int.Parse(playerProperties[currentLevel+1]["expRequired"]);

            maxHealth = float.Parse(playerProperties[currentLevel+1]["playerHP"]);

            currentRecovery = float.Parse(playerProperties[currentLevel]["recovery"]);

            currentMoveSpeed = float.Parse(playerProperties[currentLevel]["playerMoveSpd"]);
        }

        UpdateLevelText();
    }

    public void Invincible(float duration) //for immune pot //shar
    {
        if (!isInvincible) //if not invincible, make invincible and set timer to duration
        {
            isInvincible = true;
            invincibilityTimer = duration;
        }
    }

    public void Strengthen(float duration) //for strengthening pot //jj
    {
        if (!isStrengthened) //if not strengthened, make strengthened and set timer to duration
        {
            isStrengthened = true;
            strengthenTimer = duration;
        }
    }

    void UpdateLevelText()
    {
        levelText.text = "LVL" + currentLevel.ToString();
    }
}
