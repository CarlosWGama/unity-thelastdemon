using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe que cuida da Scene GameOver
/// </summary>
public class GameOver : MonoBehaviour {

    [SerializeField]
    private float time;

    [SerializeField]
    private string scene;

    [SerializeField]
    private AudioClip BGM;

    void Start() {
        SoundManager.instance.PlayBGM(BGM);
    }
	
	void Update () {
        time -= TimeManager.DeltaTimeRunning;
        if (time < 0) {
            SceneManager.LoadScene(scene);
        }
	}
}
