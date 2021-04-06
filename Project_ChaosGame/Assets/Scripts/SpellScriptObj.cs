using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SpellScriptObj : ScriptableObject 
{
    public GameObject spellPrefab;
    public float force;
    public float damage;
    public float damageRadius;
    public float spawnTime = 0.3f;
    public float lifeTime = 1.45f;
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
