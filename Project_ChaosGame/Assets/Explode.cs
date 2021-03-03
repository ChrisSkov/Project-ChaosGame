using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explode : MonoBehaviour
{
    public GameObject[] pebbles;
    public float explosionForce;

    public Transform explosionPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Detonate()
    {
        foreach (GameObject g in pebbles)
        {
            var pebbleClone = Instantiate(pebbles[Random.Range(0, pebbles.Length)].gameObject, explosionPos.position, transform.rotation);
            pebbleClone.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 1, 2, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}
