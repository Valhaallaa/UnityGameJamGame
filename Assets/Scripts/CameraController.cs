using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float RotSpeed;
    public GameObject CameraCentre;

    // the game obhect itself is set to be a child object of an empty gameobject set within the level  which it is set to point towards
    public void UpdateCamera(GameObject NewCameraPos)
    {
        CameraCentre = NewCameraPos;
        transform.position = CameraCentre.transform.position;
    }

    private void rotation()
    {
        // the camera was orignally going to have its rotation able to be changed by using Q and E to rotate the gameobject it is attached too, however due to gameplay issues
        // this was removed
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, RotSpeed * Time.deltaTime, 0, Space.World);
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, -RotSpeed * Time.deltaTime, 0, Space.World);
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
       
    }

}
