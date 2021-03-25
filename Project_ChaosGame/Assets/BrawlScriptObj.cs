using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BrawlScriptObj : ScriptableObject
{
    public float moveSpeed;
    public float moveSmoothing;
    public float rotationSpeed;
    public float maxHealth;
    public float lightAtk_1;
    public float lightAtk_2;
    public float heavyFinisherDMG;
    public float lightFinisherDMG;
    public AudioClip[] takeDmgSounds;
    public AudioClip[] finisherSounds;
    public AudioClip[] swingSounds;
    public AudioClip[] deathSounds;
    public GameObject[] attackEffects;
    public GameObject[] bloodEffects;

}
