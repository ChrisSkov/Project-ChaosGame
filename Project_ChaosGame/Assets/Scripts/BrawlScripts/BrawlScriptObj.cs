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
    public bool gameOver = false;
    public AudioClip[] takeDmgSounds;
    public AudioClip[] finisherSounds;
    public AudioClip[] swingSounds;
    public AudioClip[] deathSounds;
    public AudioClip[] impactSounds;
    public GameObject[] attackEffects;
    public GameObject[] bloodEffects;

}
