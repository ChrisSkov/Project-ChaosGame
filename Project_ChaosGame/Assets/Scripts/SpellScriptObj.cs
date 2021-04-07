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

    public GameObject collisionVFX;
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

    public void SpawnCollissionEffect(Transform pos)
    {
        GameObject clone = Instantiate(collisionVFX, pos.position, pos.rotation);
        Destroy(clone, 2f);
    }
}
