using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
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
    }

    void PauseOff()
    {
        Time.timeScale = 1;
        Debug.Log("PauseOff");
    }
}
