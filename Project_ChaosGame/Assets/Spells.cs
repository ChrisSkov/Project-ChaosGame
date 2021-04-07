using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public SpellScriptObj currentSpell;
    public Transform spellCastPos;
    public void CastSpell()
    {
        GameObject clone = Instantiate(currentSpell.spellPrefab, spellCastPos.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentSpell.force, ForceMode.Impulse);
        Destroy(clone, currentSpell.lifeTime);
    }
}
