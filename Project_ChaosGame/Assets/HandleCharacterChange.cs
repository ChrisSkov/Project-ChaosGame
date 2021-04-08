using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCharacterChange : MonoBehaviour
{

    public bool isWizard = true;
    bool wizardGearActive = false;
    public GameObject[] wizardGear;
    public Animator anim;

    public BrawlScriptObj wizardScriptObj;
    public BrawlScriptObj warriorScriptObj;

    public RuntimeAnimatorController wizardController;
    public RuntimeAnimatorController warriorController;

    BrawlController brawlControl;

    // Start is called before the first frame update
    void Start()
    {
        brawlControl = GetComponent<BrawlController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToWizard()
    {
        if (!wizardGearActive)
        {
            SetGearActiveOrInactive(true);
            brawlControl.ChangeClass(wizardScriptObj);
            SetRunTimeAnimController(wizardController);
            wizardGearActive = true;
        }
    }

    public void ChangeToWarrior()
    {
        if (wizardGearActive)
        {
            SetGearActiveOrInactive(false);
            brawlControl.ChangeClass(warriorScriptObj);
            SetRunTimeAnimController(warriorController);
            wizardGearActive = false;
        }
    }

    private void SetGearActiveOrInactive(bool myBool)
    {
        foreach (GameObject g in wizardGear)
        {
            g.SetActive(myBool);
        }
    }

    public void SetRunTimeAnimController(RuntimeAnimatorController newController)
    {
        anim.runtimeAnimatorController = newController;
    }
}
