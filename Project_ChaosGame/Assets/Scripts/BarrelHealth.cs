using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelHealth : MonoBehaviour
{
    public GameObject explosion;
    public bool isTriggered = false;
    public bool triggeredByBarrel = false;
    public float timer;
    public float timeToBlow = 2f;
    public float explosionRadius = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            timer += Time.deltaTime;
            TakeDamage();

        }
    }

    public void TakeDamage()
    {

        if (timer >= timeToBlow && triggeredByBarrel == true)
        {
            GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
            DetonateBarrel();
            Destroy(gameObject);
        }
        if (triggeredByBarrel == false)
        {
            GameObject clone = Instantiate(explosion, transform.position, transform.rotation);
            DetonateBarrel();
            Destroy(gameObject);
        }


    }

    private void DetonateBarrel()
    {
        LayerMask mask = LayerMask.GetMask("Hitable");
        foreach (Collider c in Physics.OverlapSphere(transform.position, explosionRadius, mask))
        {
            BarrelHealth hp = c.GetComponentInParent<BarrelHealth>();
            if (hp.isTriggered == false)
            {
                hp.triggeredByBarrel = true;
                hp.isTriggered = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
