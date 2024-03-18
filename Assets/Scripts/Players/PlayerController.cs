using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private KeyCode randomKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        randomKeyCode = (KeyCode)Random.Range((int)KeyCode.A, (int)KeyCode.Z); //�����_���ȃL�[��ݒ�
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(randomKeyCode); //�����_���ȃL�[�\��

        rb = this.GetComponent<Rigidbody2D>(); // Rigidbody2D�擾

        Transform myTransform = this.transform; //transform���擾
        myTransform.Translate(0.05f, 0.0f, 0.0f, Space.World); //���݂̍��W�����X���W��1�����Z���Ĉړ�
    }
    private void OnCollisionStay2D(Collision2D collision) //Player���n�ʂɂ��Ă�����
    {
        Debug.Log("touch"); //������������

        if (Input.GetKeyDown(randomKeyCode)) //���������_���ȃL�[����������
        {
            Vector3 jump = new Vector2(0.0f, 30.0f); // �W�����v�̑傫���ݒ�
            rb.AddForce(jump); // �W�����v���s
        }
    }
}
