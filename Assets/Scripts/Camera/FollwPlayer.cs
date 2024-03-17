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
        Transform myTransform = this.transform; //transform‚ğæ“¾
        myTransform.Translate(0.05f, 0.0f, 0.0f, Space.World); //Œ»İ‚ÌÀ•W‚©‚ç‚ÌXÀ•W‚ğ1‚¸‚Â‰ÁZ‚µ‚ÄˆÚ“®
    }
}
