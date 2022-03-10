using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject model;
    [SerializeField]
    private bool PrimaryPlayer;
    // a script that was intended to make the player face in the direction of theirmovement using the Axis's that they are using to move, however the script failed to work
    // and was not finished on time
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float HI = Input.GetAxis("Horizontal");
        float VI = Input.GetAxis("Vertical");
        float AHI = Input.GetAxis("AltHorizontal");
        float AVI = Input.GetAxis("AltVertical");
        Vector3 movedir = new Vector3(HI, 0, VI);
        Vector3 Altmovedir = new Vector3(AHI, 0, AVI);
        if (PrimaryPlayer) {
            
                Quaternion rot = Quaternion.LookRotation(movedir, Vector3.up);
                model.transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 5 * Time.deltaTime);
            
        }
        else
        {
            
                Quaternion rot = Quaternion.LookRotation(Altmovedir, Vector3.up);
                model.transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 5 * Time.deltaTime);
            
        }

    }
}
