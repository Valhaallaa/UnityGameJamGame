using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    GameObject teleportLocation, box;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == box)
        {
            TeleportBox();
        }
    }

    void TeleportBox()
    {
        box.transform.position = teleportLocation.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
