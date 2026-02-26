using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isrestart=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartGame()
    {
        isrestart=true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitGame()
    {
        Character.score=0;
        Application.Quit();
    }
    private void OnApplicationQuit() {
        Character.score=0;
    }
}
