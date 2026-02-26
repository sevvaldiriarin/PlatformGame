using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isrestart=false;

    // Start is called before the first frame update
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
        Player.score=0;
        Application.Quit();
    }
    private void OnApplicationQuit() {
        Player.score=0;
    }
}
