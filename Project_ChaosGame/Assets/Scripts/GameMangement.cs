using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameMangement : MonoBehaviour
{
    public PlayerInputManager instance;
    public int count = 0;
    public Transform[] spawnPoints;
    public Transform lookAtStart;
    public GameObject selectCharUI;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public void OnJoinGame(PlayerInput input)
    {
        HandleSpawnPlayerPosition(input);
        if (instance.playerCount == instance.maxPlayerCount)
        {
            selectCharUI.SetActive(false);
        }
    }

    private void HandleSpawnPlayerPosition(PlayerInput input)
    {
        input.transform.position = spawnPoints[count].position;
        input.transform.LookAt(lookAtStart.position);
        if (count < spawnPoints.Length - 1)
        {
            count++;
        }
    }


}

