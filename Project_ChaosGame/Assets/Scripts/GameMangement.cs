using System;
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
    public GameObject selectCharUI;

    public PlayerInput currentPlayerInput;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
//        print(currentPlayerInput.currentActionMap);
    }

    public Func<PlayerInput> onCreatePlayer { get; set; }

    public void OnJoinGame(PlayerInput input)
    {
        //     if (!brawl)
        //     {

        //         input.gameObject.GetComponent<Fight>().id = count;
        //         input.gameObject.GetComponent<Health>().myID = count;
        //     }
        HandleSpawnPlayerPosition(input);
        currentPlayerInput = input;
        if(instance.playerCount == instance.maxPlayerCount)
        {
            selectCharUI.SetActive(false);
        }
    }

    private void HandleSpawnPlayerPosition(PlayerInput input)
    {
        input.transform.position = spawnPoints[count].position;
        input.transform.LookAt(lookAtStart.position);
        if (count < spawnPoints.Length)
        {
            count++;
        }
    }


    public void CreatePlayer(PlayerInput input)
    {

    }
    public void OnSelectChar(int playerPrefabIndex)
    {

        // myIndex = playerPrefabIndex;
        // if (myIndex == 0)
        // {
        //     currentPlayerInput.GetComponent<SelectCharacter>().mage = true;
        //     currentPlayerInput.SwitchCurrentActionMap(currentPlayerInput.defaultActionMap);
        //     currentPlayerInput = null;
        // }
        // if (myIndex == 1)
        // {
        //     currentPlayerInput.GetComponent<SelectCharacter>().warrior = true;
        //     currentPlayerInput.SwitchCurrentActionMap(currentPlayerInput.defaultActionMap);
        //     currentPlayerInput = null;
        // }
    }
}
