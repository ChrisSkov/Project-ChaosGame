using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMangement : MonoBehaviour
{
    public PlayerInputManager instance;
    int count = 0;
    public Transform[] spawnPoints;
    public Transform lookAtStart;
    public bool brawl = true;
    public int myIndex = 0;
    public GameObject[] playerPrefabs;
    public GameObject p1;
    public GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJoinGame(PlayerInput input)
    {
        //    Instantiate(playerPrefabs[myIndex], spawnPoints[count].position, spawnPoints[count].rotation);
        //     if (!brawl)
        //     {

        //         input.gameObject.GetComponent<Fight>().id = count;
        //         input.gameObject.GetComponent<Health>().myID = count;
        //     }
        HandleSpawnPlayerPosition(input);
    }

    private void HandleSpawnPlayerPosition(PlayerInput input)
    {
        input.transform.position = spawnPoints[count].position;
        input.transform.LookAt(lookAtStart.position);
        count++;

    }

    public void OnSelectChar(int playerPrefabIndex)
    {
        
        myIndex = playerPrefabIndex;
    }
}
