using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomMat : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerScriptObj player;
    public SkinnedMeshRenderer meshRender;
    void Start()
    {

       meshRender.material = player.pantsMats[GetComponent<Fight>().id];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
