using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource source;
    public AudioClip[] musicClips;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
        {
            source.PlayOneShot(musicClips[Random.Range(0,musicClips.Length)]);
        }
    }
}
