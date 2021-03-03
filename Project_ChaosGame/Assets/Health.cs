using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    bool dead = false;

    public Slider hpSlider;
    public Text hpText;
    public int myID;
    public AudioClip[] takeDamageSound;
    public AudioClip[] impactSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = string.Format("{0}{1}", currentHealth + "/", maxHealth);
    }

    public void TakeDamage(float dmg, int id)
    {
        if (id != myID)
        {

            currentHealth -= dmg;
            GetComponent<AudioSource>().PlayOneShot(takeDamageSound[Random.Range(0, takeDamageSound.Length)]);
            GetComponent<AudioSource>().PlayOneShot(impactSound[Random.Range(0, impactSound.Length)]);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                dead = true;
            }
        }
        hpSlider.value = currentHealth;
    }
}
