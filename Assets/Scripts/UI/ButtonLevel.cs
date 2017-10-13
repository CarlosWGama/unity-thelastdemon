using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevel: MonoBehaviour {

    private void Awake() {
        Language.UpdateLanguage();
    }

    public void ButtonStoryMode() {
        //if (SaveLoad.HasSave(1))
        //    GameplayInfo.OpenLastStage();
        //else
            ChangeLevel("Inicial");
    }

    public void ChangeLevel(string level) {
        SceneManager.LoadScene(level);
    }	

    public void ButtonExit()
    {
        Application.Quit();
    }
}
