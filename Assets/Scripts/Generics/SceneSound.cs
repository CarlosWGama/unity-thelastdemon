using UnityEngine;
using System.Collections;

public class SceneSound : MonoBehaviour {

    /// <summary> Música de Fundo </summary>
    [SerializeField]
    private AudioClip BGM;

    /// <summary> Som de Fundo </summary>
    [SerializeField]
    private AudioClip BGS;

    /// <summary> Efeito </summary>
    [SerializeField]
    private AudioClip SE;

    /// <summary> Atraso para ativar o SE </summary>
    [SerializeField]
    private float delaySE;

    void Start () {
        SoundManager.instance.PlayBGM(BGM);
        SoundManager.instance.PlayBGS(BGS);
    }

    void Update() {
        if (SE != null) {
            delaySE -= TimeManager.DeltaTimeRunning;
            if (delaySE <= 0) {
                SoundManager.instance.PlaySE(SE);
                enabled = false;
            }
        } else 
            enabled = false;
        
    }
	
}
