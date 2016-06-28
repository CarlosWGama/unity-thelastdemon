using UnityEngine;
using System;

/// <summary>
/// Classe responsável por pausar os áudios durante o pause
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioPauseManager : MonoBehaviour {

    /// <summary> Tipo de Som </summary>
    enum SoundType {
        /// <summary> BackGround Music </summary>
        BGM = 1,
        /// <summary> BackGround Sound </summary>
        BGS = 2,
        /// <summary> Sound Effect </summary>
        SE = 3
    }
    /// <summary> Só que será tocado </summary>
    private AudioSource audioPlayer;
    
    /// <summary> Tipo do Som (BGM = 1 | BGS = 2 | SE = 3) </summary>
    [SerializeField]
    private SoundType typeSound;

    /// <summary> Se o som para, caso esteja no pause </summary>
    [SerializeField]
    private bool effectByPause = true;

	void Awake () {
        audioPlayer = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (effectByPause)
            audioPlayer.mute = TimeManager.Paused && !TimeManager.SemiPaused;
	}
}
