using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WinGame(int id)
    {
        text.text = "PLAYER " + id + " WINS!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
