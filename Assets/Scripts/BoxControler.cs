using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControler : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb_Parent;
    [SerializeField]
    GameObject playerToTrigger, box;
    [SerializeField]
    bool goingUp;
    bool isMoving;

    int turnCounter = 0;
    private void ResetBox()
    {
        // a function used to send the box to its respawnpoint gameobject position upon pressing the R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            box.transform.position = GameObject.Find("RespawnPoint").transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // a function used to add rigidbody forces to the box if a Player enters the trigger this script will be located on, contains  checks to see which direction the trigger controls
        // and what Player has entered the trigger as well as a check too see if the box is moving, however the movement check remained unfinished.
        if (goingUp)
        {
            if (other.gameObject.name.Contains("Player"))
             {
                if (other.gameObject.GetComponent<PlayerController>().PrimaryPlayer)
                {
                    if (other.transform.position.z < box.transform.position.z)
                    {
                        if (!isMoving)
                        {
                            rb_Parent.AddForce(transform.forward * 5f, ForceMode.Impulse);
                            turnCounter++;
                            Debug.Log("primary player enter");
                        }
                    }
                    else
                    {
                        if (!isMoving)
                        {
                            rb_Parent.AddForce(-transform.forward * 5f, ForceMode.Impulse);
                            turnCounter++;
                        }
                    }
                }
            
            }
        }
        else
        {
            if (other.gameObject.name.Contains("Player"))
            {
                if (!other.gameObject.GetComponent<PlayerController>().PrimaryPlayer)
                {
                    if (other.transform.position.x < box.transform.position.x)
                    {
                        if (!isMoving)
                        {
                            rb_Parent.AddForce(transform.right * 5f, ForceMode.Impulse);
                            turnCounter++;
                        }
                    }
                    else
                    {
                        if (!isMoving)
                        {
                            rb_Parent.AddForce(-transform.right * 5f, ForceMode.Impulse);
                            turnCounter++;
                        }

                    }
                }
            }
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        rb_Parent = GetComponentInParent<Rigidbody>();
        box = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ResetBox();
    }
}
