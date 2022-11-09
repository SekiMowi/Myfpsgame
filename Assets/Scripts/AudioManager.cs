using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;


    public void SetLevel (float audioValue)
    {
        mixer.SetFloat("AudioGame", Mathf.Log10(audioValue) * 20);//Makes audio slider work the "right" way
    }

}
