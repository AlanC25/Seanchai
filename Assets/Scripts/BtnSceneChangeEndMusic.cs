using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnSceneChangeEndMusic : MonoBehaviour
{
    public Button nextButton;
    [SerializeField]
    private string sceneNameToLoad;
    FMOD.Studio.Bus MasterBus;

    // Start is called before the first frame update
    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.AddListener(NextScene);
    }

    void NextScene()
    {
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(sceneNameToLoad);
        if (sceneNameToLoad == "Roam Area No Inventory")
        {
            ThirdPersonCharacterController.isRoaming = true;
            DialogueSystem.isTalking = false;
            CompleteGame.oengusIsComplete = true;
        }
    }
}
