using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ui_Controller : MonoBehaviour
{
    private string LevelName = "level1";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(LevelName);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
