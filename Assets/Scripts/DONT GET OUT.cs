using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DONTGETOUT : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D others)
    {
        if(others.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("level1");
        }
    }
}
