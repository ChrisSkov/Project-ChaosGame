using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BrawlAttackScriptObj : ScriptableObject
{
    public float damage = 5f;
    public float turnOnColliderTime = 0.3f;
    public float turnOffColliderTime = 0.45f;
    public Hits hitFacing;
    public Hits hitFacingAway;
    public enum Hits
    {
        HookLeft,
        HookRight,
        Uppercut,
        GutPunch,
        Straight,
        LaunchUppercut
    }
}
