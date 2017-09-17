using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel: MonoBehaviour {

    private void Awake() {
        Language.UpdateLanguage();
    }

    public void ChangeLevel(string level) {
        SceneManager.LoadScene(level);
    }	

    public void ButtonExit()
    {
        Application.Quit();
    }
}
