using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JudgeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Clear") //�����N���A�^�O��ʂ�����
        {
            SceneManager.LoadScene("GameClear"); //�Q�[���N���A�V�[���Ɉړ�
        }

        if (collision.tag == "Over") //����Over�^�O��ʂ�����
        {
            SceneManager.LoadScene("GameOver"); //�Q�[���I�[�o�[�V�[���Ɉړ�
        }
    }
}
