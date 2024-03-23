using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    private float goal = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("GameClear");
        StartScript.timeflag = false;
        
    }
    void Clear()
    {
        Debug.Log(goal);
        goal -= Time.deltaTime;
    }
}
