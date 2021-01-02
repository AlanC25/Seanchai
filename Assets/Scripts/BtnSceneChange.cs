using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnSceneChange : MonoBehaviour
{
    public Button nextButton;
    [SerializeField]
    private string sceneNameToLoad;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.AddListener(NextScene);
    }

    void NextScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
