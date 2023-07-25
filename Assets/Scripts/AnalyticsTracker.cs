using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnalyticsTracker : MonoBehaviour //jj
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
        if(!File.Exists(filePath)){ // checks for file
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine("sessionId,enemiesKilled,timeSpent,xpGained"); // adds line if file do not exist
            sw.WriteLine("1"+","+enemiesKilled+","+timeSpent+","+xpGained); // first entry
            sw.Close();
        }
        else {
            StreamReader sr = new StreamReader(filePath);
            string data = "";
            string chaser = "";
            while(data!=null){
                chaser = data;
                data = sr.ReadLine();
            }
            List<string> analytics = new List<string>(chaser.Split(","));
            sr.Close();
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine((int.Parse(analytics[0])+1).ToString()+","+enemiesKilled+","+timeSpent+","+xpGained);
            sw.Close();
        }
    }
}

