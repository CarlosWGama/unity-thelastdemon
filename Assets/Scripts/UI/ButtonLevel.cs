using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel: MonoBehaviour {

    public void ChangeLevel(string level) {
        SceneManager.LoadScene(level);
    }	
}
