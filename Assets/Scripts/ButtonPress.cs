using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField]
    GameObject boxNeeded, obstacle, objectToSpawn;
    [SerializeField]
    Material lightUpMaterial;
    [SerializeField]
    Material basicMaterial;
    [SerializeField]
    bool isActive, destroyObstacle, spawnObject;

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            PlayerPressed();
        }
        if(other.gameObject == boxNeeded)
        {
            BoxPressed();
        }
    }


    void PlayerPressed()
    {
        isActive = true;
        boxNeeded.GetComponent<MeshRenderer>().material = lightUpMaterial;

    }
    void PlayerReleased()
    {
        isActive = false;
        boxNeeded.GetComponent<MeshRenderer>().material = basicMaterial;

    }
    void BoxPressed()
    {
        if (destroyObstacle)
        {
            if (obstacle)
                obstacle.GetComponent<Obstacle>().DestroyObstacle();
        }
        if (spawnObject)
        {
            if (objectToSpawn)
                objectToSpawn.GetComponent<Obstacle>().SpawnObstacle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {

            PlayerReleased();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(boxNeeded)
        basicMaterial = boxNeeded.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
