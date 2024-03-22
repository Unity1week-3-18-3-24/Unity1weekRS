using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour
{
    // Start is called before the first frame update
    private bool flag = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(flag == false)
            {
                flag = true;
                Time.timeScale = 0;
            }

            if(flag == true)
            {
                flag = false;
                Time.timeScale = 1;
            }
        }
    }
}
