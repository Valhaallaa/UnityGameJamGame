using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool PrimaryPlayer;
    [SerializeField]
    private float MoveSpeed,JumpSpeed;
    private Rigidbody Rb;
    private Vector3 Movement;
    [SerializeField]
    private GameObject RespawnPoint;
    bool isGrounded;
    float distToGround;
    public void Respawn()
    {
        transform.position = RespawnPoint.transform.position;
    }

    private void PlayerMove()
    {
        // this function gets on against a bool to see what Axis that player gameobject will use to control it, the Axis use the Unity Inpuut system to control what they are
        // the axis variables are they added to the transform position of the object, pressing the jump key will also add a force to the rigidbody component sending them up.
        // it can however be used to fly
        if (PrimaryPlayer)
        {
            float x = Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime;
            float z = Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime;
            Movement.x = x;
            Movement.z = z;
            if (Input.GetKeyDown(KeyCode.RightControl) && Rb.velocity.y < 1)
                Rb.AddForce(0, JumpSpeed, 0, ForceMode.Impulse);
            transform.position += Movement;
        }
        else
        {
            float x = Input.GetAxisRaw("AltHorizontal") * MoveSpeed * Time.deltaTime;
            float z = Input.GetAxisRaw("AltVertical") * MoveSpeed * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && Rb.velocity.y < 1)
                Rb.AddForce(0,JumpSpeed,0,ForceMode.Impulse);
            Movement.x = x;
            Movement.z = z;
            transform.position += Movement;
        }
    }
    /*
    bool isGrounded()
    {

    }
    */
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        RespawnPoint = GameObject.Find("RespawnPoint");

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
}
