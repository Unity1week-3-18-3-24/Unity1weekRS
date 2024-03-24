using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    private float goal = 1.0f;
    public static bool flag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == true)
        {
            goal -= Time.deltaTime;
        }
        if(goal<=0)
        {
            SceneManager.LoadScene("GameClear");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            flag = true;
            StartScript.timeflag = false;
        }
    
    }
}
