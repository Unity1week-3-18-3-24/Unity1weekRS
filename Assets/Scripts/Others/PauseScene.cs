using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScene : MonoBehaviour
{
    public GameObject pauseset;
    // Start is called before the first frame update
    //private bool flag = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                PauseOn();
            }
            else if(Time.timeScale == 0)
            {
                PauseOff();
            }
        }
    }

    void PauseOn()
    {
        Time.timeScale = 0;
        Debug.Log("PauseOn");
        pauseset.SetActive(true);
    }

    void PauseOff()
    {
        Time.timeScale = 1;
        Debug.Log("PauseOff");
        pauseset.SetActive(false);
    }

    public void Back()
    {
        Debug.Log("Back");
        Time.timeScale = 1;
        pauseset.SetActive(false);
    }

    public void Finish()
    {
        Debug.Log("Finish");
        SceneManager.LoadScene("Title");
        pauseset.SetActive(false);
    }

    public void Retry()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene("Main");
        StartScript.gametime = 0;
        pauseset.SetActive(false);
    }
    public void Kaisi()
    {
        SceneManager.LoadScene("Main");
    }
}
