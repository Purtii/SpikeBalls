using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class RestartLevelOnCollision : MonoBehaviour
{
    public int Respawn;
    public bool isopened = false;
    public GameObject PauseMenu;
    public TextMeshProUGUI ScoreText,ScoreText1;
    private void Start()
    {
        ScoreText.text = "Player 1 : " + PlayerPrefs.GetInt("Score1",0).ToString();

        ScoreText1.text = "Player 2 : " + PlayerPrefs.GetInt("Score2",0).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") )             
        {
            PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2", 0 )+1);
            PlayerPrefs.Save();
            

            SceneManager.LoadScene(Respawn);
        }
        if(other.CompareTag("Player2"))
        {
            PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Score1", 0) + 1);
            PlayerPrefs.Save();
            
            SceneManager.LoadScene(Respawn);
        }
       }

    public void OnApplicationQuit()
    {

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

    }
    public void Quit()
    {
        
        OnApplicationQuit();
        Application.Quit(); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (isopened == false)
            {
                PauseMenu.SetActive(true);
                isopened = true;
                Time.timeScale = 0;
            }
            else
            {
                PauseMenu.SetActive(false);
                isopened = false;
                Time.timeScale = 1;
            }
        } 
    }
}



