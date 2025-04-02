using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    //�@AudioSource�R���|�[�l���g
    //private AudioSource audioSource;
    //�@�����ɕۑ������e�N�X�`����\������RawImageUI
    //public RawImage rawImage;
    //�@�����X�N���v�g���o�͂���UI��Texture���Z�b�g�������ǂ���
    //private bool check = false;

    [SerializeField] private GameObject Select_Object;

    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += LoopPointReached;
        //�@�X�N���v�g��AudioOutputMode��AudioSource�ɕύX
        //videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //�@Direct���[�h
        //mPlayer.audioOutputMode = VideoAudioOutputMode.Direct;
        //audioSource = GetComponent<AudioSource>();
        //�@�I�[�f�B�I�g���b�N��L���ɂ���
        //videoPlayer.EnableAudioTrack(0, true);
        //�@AudioOutPut��AudioSource�̎��ɃX�N���v�g����AudioSource��ݒ肷��B
        //videoPlayer.SetTargetAudioSource(0, audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoopPointReached(VideoPlayer videoPlayer)
    {
        StageSerect script = Select_Object.GetComponent<StageSerect>();
        script.GetSerect();
    }
   
    public void PlayVideo()
    {
        videoPlayer.Play();
    }
}
