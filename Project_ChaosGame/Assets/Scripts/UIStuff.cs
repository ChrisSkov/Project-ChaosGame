using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{
    public PlayerScriptObj player;
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "X " + player.currentBarrels;
    }
}
