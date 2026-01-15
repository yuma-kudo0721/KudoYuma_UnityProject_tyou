using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private List<AudioSource> mSeList = new List<AudioSource>();
    [SerializeField]
    private List<AudioSource> mBGMList = new List<AudioSource>();
 
    public enum eSeList {
        None = -1,
        clear,
        poor,
        start,
        good,
        bad,
        playStart,
        _max
    }

    public enum eBGMList {
        None = -1,
        TITLE,
        PLAY,
        RESULT_Clear,
        RESULT_Gameover,
        _max
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // SE�R�[��
    public void PlaySE( eSeList seId ){
        mSeList[(int)seId].Play();
    }

    // BGM�R�[��
    public void PlayBGM( eBGMList bgmId ){
        mBGMList[(int)bgmId].Play();
    }


    // BGM�X�g�b�v
    public void StopBGM( eBGMList bgmId ){
        mBGMList[(int)bgmId].Stop();
    }



}
