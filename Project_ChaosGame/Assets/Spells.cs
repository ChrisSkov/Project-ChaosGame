using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject lightAttackPrefab;
    public GameObject heavyAttackPrefab;

    public Transform spellCastPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSpellEffect(GameObject spell)
    {
        GameObject clone = Instantiate(spell, spellCastPos.position,Quaternion.identity);
    }
}
