using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(RestartTheGame);
    }
    
    public void RestartTheGame()
    {
        SceneManager.LoadScene(0);
    }
}
