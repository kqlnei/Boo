using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseAnimScript : MonoBehaviour
{
    private bool isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating)
        {
            // �ԕr��O�i�����鏈��������
            // �Ⴆ�΁Atransform.Translate��Rigidbody���g�p���Ĉړ������邱�Ƃ��ł��܂�

            // �ԕr���n�ʂɓ��B������
            if (transform.position.y <= 0.0f)
            {
                // �A�j���[�V�����I����A���b��ɉԕr�����ł�����
                Destroy(gameObject, 5.0f);
            }
        }
    }
    public void StartAnimation()
    {
        // �A�j���[�V�������J�n
        isAnimating = true;
        // �A�j���[�V�������Đ����邽�߂̃g���K�[���Z�b�g�iAnimator�R���g���[���[�̃g���K�[���ɍ��킹�Đݒ�j
        GetComponent<Animator>().SetTrigger("StartAnimation");
    }
}
