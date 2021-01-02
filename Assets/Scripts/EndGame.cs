using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Button endButton;
    void Start()
    {
        Button btn = endButton.GetComponent<Button>();
        btn.onClick.AddListener(doExitGame);
    }

    void doExitGame()
    {
        Application.Quit();
    }
}
