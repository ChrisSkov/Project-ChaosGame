using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    PlayerAnimation playerAnim;
    [Header("Health values")]
    public float maxHealth = 100f;
    public float currentHealth;
    public bool dead = false;
    [Header("UI")]
    public Slider hpSlider;
    public Text hpText;
    public int myID;
    [Header("Audio")]
    public AudioClip[] takeDamageSound;
    public AudioClip[] blockSounds;
    public AudioClip[] impactSound;
    AudioSource source;
    [Header("Effects")]
    public Transform bloodPos;
    public GameObject chillBlood;

     GameObject gameOverScreen;

    bool reducedDMG = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = GameObject.FindGameObjectWithTag("Menu");
        playerAnim = GetComponent<PlayerAnimation>();
        source = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = string.Format("{0}{1}", currentHealth + "/", maxHealth);
        if(dead)
        {
            gameOverScreen.SetActive(true);
        }
        else{
            gameOverScreen.SetActive(false);
        }
    }

    public void TakeDamage(float dmg, int id)
    {
        if (dead)
            return;
        if (id != myID)
        {
            if (reducedDMG)
            {
                currentHealth -= dmg / 2;
                PlayImpactSound(takeDamageSound);
                PlayImpactSound(impactSound);
                playerAnim.PlayTakeDamage();
            }
            else if (GetComponent<Fight>().blockAttacks == true)
            {
                playerAnim.PlayBlockImpactAnim();
                PlayImpactSound(blockSounds);
            }
            else
            {
                currentHealth -= dmg;
                PlayImpactSound(takeDamageSound);
                PlayImpactSound(impactSound);
                playerAnim.PlayTakeDamage();
            }
            //  GetComponent<AudioSource>().PlayOneShot(impactSound[Random.Range(0, impactSound.Length)]);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (!dead)
                {
                    playerAnim.PlayDeathAnimation();
                    SpawnChillBlood();
                    dead = true;
                }
            }
        }
        hpSlider.value = currentHealth;
    }



    public void SpawnChillBlood()
    {
        GameObject bloodClone = Instantiate(chillBlood, bloodPos.position, bloodPos.rotation);
        Destroy(bloodClone, 2f);

    }

    private void PlayImpactSound(AudioClip[] clipArray)
    {
        source.PlayOneShot(clipArray[Random.Range(0, clipArray.Length)]);
    }

    public void TakeReducedDMG()
    {
        reducedDMG = true;
    }
    public void TakeFullDMG()
    {
        reducedDMG = false;
    }


}
