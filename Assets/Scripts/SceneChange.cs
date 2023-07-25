using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // jj
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    public void Press(string sceneToChange)
    {
        SceneManager.LoadScene(sceneToChange);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
