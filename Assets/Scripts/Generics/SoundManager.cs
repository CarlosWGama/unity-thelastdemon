using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Classe responsável pelas músicas e sons tocados no jogo
/// </summary>
public class SoundManager : MonoBehaviour {

    [Header("BGM")]
    [SerializeField]
    private AudioSource BGM;
    [SerializeField]
    private List<AudioClip> musics;
    public enum Music {
        Null = -1,
        MainMenu = 0,   //01 - Menu - Ross Bugden - Sad
        Intro = 1,      
        House = 2,
        Game = 3,
        Credits = 4,
    }

    [Header("BGS")]
    [SerializeField]
    private AudioSource BGS;
    [SerializeField]
    private List<AudioClip> backgroundSounds;
    public enum BackgroundSound {
        Null = -1
    }

    [Header("SE")]
    [SerializeField]
    private AudioSource SE;
    public enum SoundEffect {
        Null = -1,
        Button = 0,
        Speech = 1,
        Success = 2,
        Fail = 3
    }
    [SerializeField]
    private List<AudioClip> soundEffects;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<SoundManager>().Length > 1)
            Destroy(gameObject);

        UpdateVolume();

    }

    public void PlayBGM(Music music) {
        BGM.clip = musics[(int)music];
        BGM.Play();
    }

    public void StopBGM() {
        BGM.Stop();
    }

    public void PlayBGS(BackgroundSound bgs) {
        BGS.clip = backgroundSounds[(int)bgs];
        BGS.Play();
    }

    public void StopBGS() {
        BGS.Stop();
    }

    public void PlaySE(SoundEffect se) {
        SE.PlayOneShot(soundEffects[(int)se]);
    }

    public void StopSE() {
        SE.Stop();
    }

    public void PlayButton() {
        PlaySE(SoundEffect.Button);
    }

    public void UpdateVolume() {
        if (PlayerPrefs.HasKey("BGM")) 
            BGM.volume = PlayerPrefs.GetFloat("BGM");
        

        if (PlayerPrefs.HasKey("BGS"))
            BGS.volume = PlayerPrefs.GetFloat("BGS");


        if (PlayerPrefs.HasKey("SE"))
            SE.volume = PlayerPrefs.GetFloat("SE");

    }
}
