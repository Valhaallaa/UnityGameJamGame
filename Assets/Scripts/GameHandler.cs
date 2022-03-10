using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameHandler : MonoBehaviour
{

    public float startTime, currTime;
    bool isPaused;
    public bool hasWon;

    void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    void WinGame()
    {
        SceneManager.LoadScene(3);
    }
    // Start is called before the first frame update
    void Start()
    {
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused)
        {
            if(currTime > 0)
                currTime = Mathf.RoundToInt(startTime -= Time.deltaTime);
            if (currTime <= 0)
                GameOver();
        }
        if (hasWon)
            WinGame();
    }
}
