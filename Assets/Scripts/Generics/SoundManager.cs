using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Classe responsável pelas músicas e sons tocados no jogo
/// </summary>
public class SoundManager : MonoBehaviour {

    [Header("Sons")]
    [SerializeField]
    private AudioSource BGM;
    
    [SerializeField]
    private AudioSource BGS;


    [SerializeField]
    private AudioSource SE;

    public static SoundManager instance;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<SoundManager>().Length > 1)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void PlayBGM(AudioClip audio) {
        if (audio != null) {
            if (BGM.clip != audio) { 
                BGM.clip = audio;
                BGM.Play();
            }
        }
        else
            StopBGM();
    }

    public void StopBGM() {
        BGM.Stop();
    }

    public void PlayBGS(AudioClip audio) {
        if (audio != null) {
            if (BGS.clip != audio) {
                BGS.clip = audio;
                BGS.Play();
            }
        } else
            StopBGS();
    }

    public void StopBGS() {
        BGS.Stop();
    }

    public void PlaySE(AudioClip audio) {
        SE.PlayOneShot(audio);
    }

    public void StopSE() {
        SE.Stop();
    }

    public void TurnOn() {
        BGM.volume = 1;
        BGS.volume = 1;
        SE.volume = 1;
    }

    public void TurnOff() {
        BGM.volume = 0;
        BGS.volume = 0;
        SE.volume = 0;
    }

}
