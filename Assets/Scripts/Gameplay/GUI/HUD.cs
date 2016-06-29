using UnityEngine;
using UnityEngine.SceneManagement;


public class HUD : MonoBehaviour {

	void Awake () {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<HUD>().Length > 1)
            Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        var currentScene = SceneManager.GetActiveScene();

        //Destroi a Scene se não tiver no GamePlay
        if (!currentScene.path.Substring(0, 23).Equals("Assets/Scenes/Gameplay/"))
            Destroy(gameObject);
	}
}
