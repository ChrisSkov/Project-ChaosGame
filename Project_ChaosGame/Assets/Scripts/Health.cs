using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    PlayerAnimation playerAnim;
    public InputActionAsset actionMaps;
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
    public bool winner = false;
    public UIControl uIControl;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = GameObject.FindGameObjectWithTag("Menu");
        playerAnim = GetComponent<PlayerAnimation>();
        source = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        hpSlider.maxValue = maxHealth;
        dead = false;
       // GetComponent<PlayerInput>().currentActionMap = actionMaps.FindActionMap("Player");
        winner = false;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = string.Format("{0}{1}", currentHealth + "/", maxHealth);
        if (dead)
        {
            gameOverScreen.transform.GetChild(0).gameObject.SetActive(true);
        }
        // else
        // {
        //     gameOverScreen.transform.GetChild(0).gameObject.SetActive(false);

        // }
        if (winner)
        {
            //GetComponent<PlayerInput>().currentActionMap = actionMaps.FindActionMap("Menu");
            gameOverScreen.GetComponent<UIControl>().WinGame(myID + 1);
            playerAnim.playerAnimator.SetTrigger("winner");
            GetComponent<PlayerMovement>().canMove = false;
        }
        else
        {
            return;
        }
    }

    public void TakeDamage(float dmg, int id, GameObject attacker)
    {
       

        if (dead)
        {
            GetComponent<PlayerMovement>().canMove = false;
            return;
        }
        if (id != myID)
        {
            print("hej");
            if (reducedDMG)
            {
                currentHealth -= dmg / 2;
                PlayTakeDMGSound();
                playerAnim.PlayTakeDamage();
            }
            else if (GetComponent<Fight>().blockAttacks == true)
            {
                playerAnim.PlayBlockImpactAnim();
                PlayImpactSound(blockSounds);
                attacker.GetComponent<PlayerAnimation>().PlayHitBackAnim();

            }
            else if (playerAnim.playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Throw_Victim"))
            {
                currentHealth -= dmg;
                PlayTakeDMGSound();
            }
            else
            {
                currentHealth -= dmg;
                PlayTakeDMGSound();
                playerAnim.PlayTakeDamage();
            }
            //  GetComponent<AudioSource>().PlayOneShot(impactSound[Random.Range(0, impactSound.Length)]);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (!dead)
                {
                    playerAnim.PlayDeathAnimation();
                    attacker.GetComponent<Health>().winner = true;
                    SpawnChillBlood();
                    dead = true;
                }
            }
        }
        hpSlider.value = currentHealth;
    }

    private void PlayTakeDMGSound()
    {
        PlayImpactSound(takeDamageSound);
        PlayImpactSound(impactSound);
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
