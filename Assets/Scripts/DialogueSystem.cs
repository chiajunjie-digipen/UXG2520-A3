using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI characterName;
    // start of getting data
    private string data = "";
    public Dictionary<int, Dictionary<string, string>> dialogueProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();
    // end of getting data
    public float textSpeed;
    
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;

        StreamReader reader = new StreamReader("Assets/CSVs/dialogue.csv");
        properties = new List<string>(reader.ReadLine().Split(','));
        data = reader.ReadLine();
        
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            dialogueProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                dialogueProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
                //Debug.Log(dataList[0] + " " + property + " " + dataList[counter]);
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close(); 

        characterName.text = dialogueProperties[index]["character_name"];
        StartDialogue(index);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == dialogueProperties[index]["dialogue_text"])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = dialogueProperties[index]["dialogue_text"];
            }
        }
    }

    void StartDialogue(int index)
    {
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueProperties[index]["dialogue_text"].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (dialogueProperties[index]["next_dialogue"] != "-1")
        {
            index++;
            textComponent.text = string.Empty;
            characterName.text = dialogueProperties[index]["character_name"];
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene(dialogueProperties[index]["nextScene"]);
        }
    }
}

