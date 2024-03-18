using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform; //transform??????
        myTransform.Translate(0.01f, 0.0f, 0.0f, Space.World); //?????????W??????X???W??1???????Z????????
    }
}
