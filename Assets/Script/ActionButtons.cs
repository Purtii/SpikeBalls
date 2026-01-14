using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayActionButton : MonoBehaviour
{
    
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
}
