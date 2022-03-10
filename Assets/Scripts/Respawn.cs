using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject RespawnPoint,PlayerRespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // a function that will run whenever an object enters the trigger, if the objects are either the box or the player it will send them too the gameobjects name
        // as their respawn points, these gameobjects are a seriaizedfield seen at the top of the script
        if (other.name.Contains("Box"))
        {
            other.gameObject.transform.position = RespawnPoint.transform.position;
        }
        else if (other.name.Contains("Player"))
        {
            other.gameObject.transform.position = PlayerRespawnPoint.transform.position;
        }
        else
        {
          // Destroy(other.gameObject);
        }
    }
    void Start()
    {
        RespawnPoint = GameObject.Find("RespawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
