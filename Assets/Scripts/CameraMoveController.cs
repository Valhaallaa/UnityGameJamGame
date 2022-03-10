using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    private int Playercount;
    [SerializeField]
    private GameObject CameraPos,InvisibleWall,InvisibleWallBehind,NewRespawnPoint,NewPlayerRespawnPoint,NextLevel,PrevLevel;
    private CameraController CamController;
    private GameObject RespawnPoint,PlayerRespawnPoint;
    
    private void SetCamera()
    {
        CamController.UpdateCamera(CameraPos); // this sets the gameobject the camera is a child too to a new position
        InvisibleWall.SetActive(false); // these enable and disable invisible walls within the game to stop one player moving or falling off while waiting for the other.
        InvisibleWallBehind.SetActive(true);
        if(NewRespawnPoint != null) // if a new respawn point is assigned it will update the position of the respawnpoint gameobject which is where the objects are moved to upon respawning
        {
            RespawnPoint.transform.position = NewRespawnPoint.transform.position;
        }
        if(NewPlayerRespawnPoint != null)
            PlayerRespawnPoint.transform.position = NewPlayerRespawnPoint.transform.position;
        if (NextLevel) // these enable and disable the current and previous level which are all children to empty gameobjects
            NextLevel.SetActive(true);
        if (PrevLevel)
            PrevLevel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // on entering the trigger a single playerobject would add one too the playercount int variable, upon reaching 2 it would run the SetCamera function
        if (other.gameObject.name.Contains("Player"))
            Playercount++;
        if (Playercount == 2)
            SetCamera();

    }

    private void OnTriggerExit(Collider other)
    {
        // takes a int away from the playercount variable if a player leaves the trigger area
        if (other.gameObject.name.Contains("Player"))
            Playercount--;
    }
    // Start is called before the first frame update
    void Start()
    {
        Playercount = 0;
        CamController = Camera.main.transform.parent.gameObject.GetComponent<CameraController>();
        RespawnPoint = GameObject.Find("RespawnPoint");
        PlayerRespawnPoint = GameObject.Find("PlayerRespawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
