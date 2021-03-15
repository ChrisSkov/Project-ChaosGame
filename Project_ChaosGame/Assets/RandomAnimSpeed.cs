using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimSpeed : MonoBehaviour
{
    public float minSpeed = 0.02f;
    public float maxSpeed = 2.5f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("speed", Random.Range(minSpeed, maxSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
