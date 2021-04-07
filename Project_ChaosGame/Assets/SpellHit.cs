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
            hasSpawnedEffect = true;
            other.gameObject.GetComponent<BrawlHealth>().TakeSpellDamage(mySpell);
            mySpell.SpawnCollissionEffect(effectPos);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag != "Ground")
        {
            hasSpawnedEffect = true;
            mySpell.SpawnCollissionEffect(effectPos);
            Destroy(gameObject);
        }
    }
}
