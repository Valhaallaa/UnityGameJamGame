using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UserInterface : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timerTextBox;
    [SerializeField]
    GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerTextBox.text = gameHandler.currTime.ToString();
    }
}
