using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameHandler gameHandler;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            gameHandler.hasWon = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
