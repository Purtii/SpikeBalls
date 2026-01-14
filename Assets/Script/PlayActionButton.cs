using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class ActionButtons : MonoBehaviour
{
    public Slider Volumeslider;
    public AudioMixer Volume;  
    
    public void PlayButton (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {
                Debug.Log(operation.progress);
            yield return null;
        }
    }
   
    public void QuitButton()
    {
        Application.Quit();
    }

    public void VolumeGame(float volume)
    {
        Volume.SetFloat("Overall", Mathf.Log10(volume) * 20);

    }
    

}
