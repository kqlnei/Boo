using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FeedScript : MonoBehaviour
{
    public enum Feed
    {
        None = 0,
        FeedIn = -1,
        FeedOut = 1,
    };

    [Header("���s����")]
    public bool Strat_Move = true;

    [Space]
    [Header("�t�F�[�h�C�����t�F�[�h�A�E�g��")]
    public Feed Feed_Move = Feed.None;
    //�C���͏��X�Ɍ���遁�X�N���[��������
    //�A�E�g�͏��X�ɏ����Ă������X�N���[���\��������

    [Header("���x (0.000f�`)")]
    public float speed = 0.01f;  //�������̑���

    [Header("�F�̕ύX")]
    public Color32 Feed_Color;

    float alfa = 0.0f;    //A�l�𑀍삷�邽�߂̕ϐ�

    byte Red;    //RGB�𑀍삷�邽�߂̕ϐ�
    byte Green;
    byte Blue;

    const byte Max_byte = 255;
    const byte Min_byte = 0;

    void Start()
    {
        if(Feed_Move == Feed.FeedOut)
            alfa = Min_byte;
        else if (Feed_Move == Feed.FeedIn)
            alfa = Max_byte;

        
        Red = Feed_Color.r;
        Green = Feed_Color.g;
        Blue = Feed_Color.b;
        
        Feed_Color = new Color32(Red, Green, Blue, (byte)alfa);
        GetComponent<Image>().color = Feed_Color;
    }

    void Update()
    {
        if (alfa >= Min_byte && alfa <= Max_byte && Feed_Move != Feed.None && Strat_Move)
        {
            Feed_Color = new Color32(Red, Green, Blue, (byte)alfa);
            GetComponent<Image>().color = Feed_Color;

            alfa += speed * (float)Feed_Move;
            if (alfa > Max_byte) alfa = Max_byte; if (alfa < Min_byte) alfa = Min_byte;
        }
    }
}
