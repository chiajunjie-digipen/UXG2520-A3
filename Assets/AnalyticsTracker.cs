using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnalyticsTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemiesKilled;
    public float timeSpent;
    public int xpGained;
    public bool counting;
    void Start()
    {
        counting = true;
        enemiesKilled = xpGained = 0;
        timeSpent = 0; // for some reason i cant put a float above so whatever i dont wanna risk anything
    }

    void Update() {
        if (counting) {
            timeSpent += Time.deltaTime;
        }
    }

    // Update is called once per frame
    public void WriteData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "saveData.csv");
        Debug.Log(filePath);
        StreamWriter sr = new StreamWriter(filePath, true);
        sr.WriteLine(enemiesKilled+","+timeSpent+","+xpGained);
        sr.Close();
    }
}

