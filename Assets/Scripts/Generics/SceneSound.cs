using UnityEngine;
using System.Collections;

public class SceneSound : MonoBehaviour {

    /// <summary> Música de Fundo </summary>
    [SerializeField]
    private AudioClip BGM;

    /// <summary> Som de Fundo </summary>
    [SerializeField]
    private AudioClip BGS;

    
    void Start () {

        SoundManager.instance.PlayBGM(BGM);
        SoundManager.instance.PlayBGS(BGS);
    }
	
}
