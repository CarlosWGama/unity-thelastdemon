using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla o evento de dialogo
/// </summary>
public class DialogoController : MonoBehaviour {

    private Event eventPlayer;

    [SerializeField]
    private string proximaScene;

	void Start () {
        PlayerInfo.RestoreHP();
        eventPlayer = FindObjectOfType<Event>();
	}

    void Update() {
        if (!eventPlayer.IsPlaying) SceneManager.LoadScene(proximaScene);
    }
}
