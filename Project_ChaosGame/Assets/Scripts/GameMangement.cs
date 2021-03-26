using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMangement : MonoBehaviour
{
    public static PlayerInputManager instance;
    int count = 0;
    public Transform[] spawnPoints;
    public Transform lookAtStart;
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
        input.transform.position = spawnPoints[count].position;
      //  input.gameObject.GetComponent<Fight>().id = count;
      //  input.gameObject.GetComponent<Health>().myID = count;
        input.transform.LookAt(lookAtStart.position);
        count ++;

    }
}
