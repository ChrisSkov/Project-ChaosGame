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
    // Start is called before the first frame update
    void Start()
    {
        myInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

        if (mage)
        {
          //  myInput.DeactivateInput();
            transform.GetChild(0).gameObject.SetActive(true);
            GetScripts(0);
        }
        if (warrior)
        {
            //myInput.DeactivateInput();
            GetScripts(1);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void GetScripts(int child)
    {
       myPlayer = transform.GetChild(child).GetComponent<BrawlHealth>().player;
       GetComponent<BrawlHealth>().player = myPlayer;
       GetComponent<BrawlMove>().player = myPlayer;
       GetComponent<KirkFu>().player = myPlayer;
       GetComponent<BrawlController>().brawlerTattie = myPlayer;
       GetComponent<BrawlAnim>().anim = transform.GetChild(child).GetComponent<Animator>();
    }
}
