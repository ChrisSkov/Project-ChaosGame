using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrawlHealth : MonoBehaviour
{
    public BrawlScriptObj player;
    public Transform bloodPos;
    public float currentHealth;
    public bool isDead = false;
    [Header("UI")]
    public Slider hpSlider;
    public Text hpText;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        player.gameOver = false;
        currentHealth = player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HandleDeath();
    }

    public void BrawlTakeDamage(float damage)
    {
        currentHealth -= damage;
        source.PlayOneShot(ChooseRandomHurtSound());
        UpdateHealthUI();
    }

    private AudioClip ChooseRandomHurtSound()
    {
        return player.takeDmgSounds[Random.Range(0, player.takeDmgSounds.Length)];
    }

    public void SpawnChillBlood()
    {
        GameObject bloodClone = Instantiate(ChooseRandomBloodEffect(), bloodPos.position, bloodPos.rotation);
        Destroy(bloodClone, 2f);

    }

    private GameObject ChooseRandomBloodEffect()
    {
        return player.bloodEffects[Random.Range(0, player.bloodEffects.Length)];
    }

    private void UpdateHealthUI()
    {
        hpSlider.value = currentHealth;
        hpText.text = string.Format("{0}{1}", currentHealth + "/", player.maxHealth);
    }

    private void HandleDeath()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            player.gameOver = true;
        }
    }
}
