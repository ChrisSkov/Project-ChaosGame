using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    Fight fight;
   // bool hasDoneDMG = false;

    Collider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        fight = GetComponentInParent<Fight>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fight.DetectHit(other);
            myCollider.enabled = false;
        }

    }
}
