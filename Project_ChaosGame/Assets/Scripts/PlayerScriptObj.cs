using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerScriptObj : ScriptableObject
{
    public float moveSpeed;
    public float turnSpeed;
    public int currentBarrels;
    public int maxBarrels;
    public bool canPickUpBarrel;
    public GameObject barrelToPickUp;
    public Vector3 myPosition;
    public float barrelOffset;
    public GameObject barrelPrefab;
    public Material[] pantsMats;
    public GameObject[] weapons;
    public GameObject[] shields;

  
}
