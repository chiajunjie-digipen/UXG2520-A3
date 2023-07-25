using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reactive : MonoBehaviour
{
    // jj
    DialogueSystem ds;
    [SerializeField] string me;
    void Start()
    {
        ds = GameObject.FindObjectOfType<DialogueSystem>();
    }

    void Update()
    {
        if(ds.characterName.text == me) {
            GetComponent<Image>().color = Color.white;
        } else {
            GetComponent<Image>().color = Color.gray;
        }
    }
}
