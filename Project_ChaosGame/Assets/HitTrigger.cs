using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    Fight fight = null;
    KirkFu brawler = null;

    // bool hasDoneDMG = false;
    public bool brawl = true;
    Collider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();

        if (!brawl)
        {
            fight = GetComponentInParent<Fight>();
        }
        else
        {
            brawler = GetComponentInParent<KirkFu>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!brawl)
            {
                fight.DetectHit(other);
            }
            else
            {
                other.gameObject.GetComponent<BrawlHealth>().BrawlTakeDamage(brawler.GetCurrentDamage());
                brawler.hasHit = true;
            }
            myCollider.enabled = false;
        }

    }
}
