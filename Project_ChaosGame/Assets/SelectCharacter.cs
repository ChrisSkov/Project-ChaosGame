using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectCharacter : MonoBehaviour
{

    PlayerInput myInput;
    BrawlScriptObj myPlayer;
    public bool mage = false;
    public bool warrior = false;
    public bool hasSelectedChar = false;
    public bool charSelectMove = false;
    // Start is called before the first frame update
    void Start()
    {
        myInput = GetComponent<PlayerInput>();
        if (mage)
        {
            ChooseMage();
        }
        if (warrior)
        {
            ChooseWarrior();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!warrior && !mage)
        {
            hasSelectedChar = false;
        }
        else
        {
            hasSelectedChar = true;
        }
    }

    public void ChooseWarrior()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        charSelectMove = true;
    }

    public void ChooseMage()
    {

        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        charSelectMove = true;
    }
}
