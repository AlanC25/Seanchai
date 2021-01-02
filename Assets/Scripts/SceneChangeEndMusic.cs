using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeEndMusic : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;
    FMOD.Studio.Bus MasterBus;

    public FadeScript fScript;

    private void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
        MasterBus.setVolume(1);
    }

    void OnTriggerEnter(Collider other)
    {
        fScript.playFadeAnim();
        StartCoroutine(WaitForFade());
    }

    IEnumerator WaitForFade()
    {
        MasterBus.setVolume(1);
        yield return new WaitForSeconds(1f);
        MasterBus.setVolume(.8f);
        yield return new WaitForSeconds(1f);
        MasterBus.setVolume(.6f);
        yield return new WaitForSeconds(.5f);
        MasterBus.setVolume(.3f);
        yield return new WaitForSeconds(.5f);
        MasterBus.setVolume(.1f);    
        yield return new WaitForSeconds(.5f);
        MasterBus.setVolume(.05f);    
        yield return new WaitForSeconds(.5f);
        MasterBus.setVolume(0);   
        //stop instrumental
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        yield return new WaitForSeconds(1.5f);
        MasterBus.setVolume(1);
        //Load next Scene
        SceneManager.LoadScene(sceneNameToLoad);
    }

    public void ButtonEndMusicAndScene()
    {
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
