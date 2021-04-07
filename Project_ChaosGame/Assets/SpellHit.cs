using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHit : MonoBehaviour
{

    public SpellScriptObj mySpell;
    public Transform effectPos;
    public bool hasSpawnedEffect = false;
    // Start is called before the first frame update
    void Start()
    {
        hasSpawnedEffect = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !hasSpawnedEffect)
        {
            other.gameObject.GetComponent<BrawlHealth>().TakeSpellDamage(mySpell);
            mySpell.SpawnCollissionEffect(other.gameObject.transform);
            hasSpawnedEffect = true;
            Destroy(gameObject);
        }
        if (other.gameObject.tag != "Ground")
        {
            mySpell.SpawnCollissionEffect(effectPos);
            Destroy(gameObject);
        }
    }
}
