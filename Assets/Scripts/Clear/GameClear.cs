using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    private float goal = 3.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        Debug.Log(collisionInfo);
        if(collisionInfo.collider.tag == "Clear")
        {
            Clear();
        }
    }

    void Clear()
    {
        Debug.Log(goal);
        goal -= Time.deltaTime;
        if(goal <= 0)
        {
            Debug.Log("clear");
            SceneManager.LoadScene("GameClear");
        }
    }
}
