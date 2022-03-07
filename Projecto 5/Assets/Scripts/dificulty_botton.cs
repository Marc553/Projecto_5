using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dificulty_botton : MonoBehaviour
{
    private Button button;
    private GameManager gameManagerScript;

    public int diffuculty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManagerScript = FindObjectOfType<GameManager>();
    }

    public void SetDifficulty()
    {
        gameManagerScript.StartGame(diffuculty);
    }

}    
