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

    /// <summary>
    /// Instancia da classe atual que permite usa-la sem buscar
    /// </summary>
    public static SoundManager instance;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<SoundManager>().Length > 1)
            Destroy(gameObject);
        else
            instance = this;
    }

    /// <summary>
    /// Inicia uma música de fundo tocada
    /// </summary>
    /// <param name="audio">Música a ser tocada</param>
    /// <param name="loop">Caso deva ser executada em loop</param>
    public void PlayBGM(AudioClip audio, bool loop = true) {
        if (audio != null) {
            if (BGM.clip != audio) {
                BGM.loop = loop;
                BGM.clip = audio;
                BGM.Play();
            }
        }
        else
            StopBGM();
    }

    /// <summary>
    /// Para de tocar a música
    /// </summary>
    public void StopBGM() {
        BGM.Stop();
    }

    /// <summary>
    /// Inicia um som de fundo tocado
    /// </summary>
    /// <param name="audio">Som a ser tocado</param>
    /// <param name="loop">Caso deva ser executado em loop</param>
    public void PlayBGS(AudioClip audio, bool loop = true) {
        if (audio != null) {
            if (BGS.clip != audio) {
                BGS.loop = loop;
                BGS.clip = audio;
                BGS.Play();
            }
        } else
            StopBGS();
    }

    /// <summary>
    /// Para de tocar o som
    /// </summary>
    public void StopBGS() {
        BGS.Stop();
    }

    /// <summary>
    /// Toca um áudio em One Shot
    /// </summary>
    /// <param name="audio">Áudio a ser tocado</param>
    public void PlaySE(AudioClip audio) {
        SE.PlayOneShot(audio);
    }

    /// <summary>
    /// Para o áudio
    /// </summary>
    public void StopSE() {
        SE.Stop();
    }

    /// <summary>
    /// Habilita o volume
    /// </summary>
    public void TurnOn() {
        BGM.volume = 1;
        BGS.volume = 1;
        SE.volume = 1;
    }

    /// <summary>
    /// Desabilita o volume
    /// </summary>
    public void TurnOff() {
        BGM.volume = 0;
        BGS.volume = 0;
        SE.volume = 0;
    }

}
