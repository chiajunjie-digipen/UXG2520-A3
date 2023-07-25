using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactive : MonoBehaviour
{
    // Start is called before the first frame update
    DialogueSystem ds;
    [SerializeField] string me;
    void Start()
    {
        ds = GameObject.FindObjectOfType<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ds.characterName.text == me) {
            GetComponent<Image>().color = Color.white;
        } else {
            GetComponent<Image>().color = Color.gray;
        }
    }
}
