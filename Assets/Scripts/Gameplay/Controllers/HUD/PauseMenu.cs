using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu de Pause durante o jogo
/// </summary>
public class PauseMenu : MonoBehaviour {

    /// <summary> Painel com a UI do menu </summary>
    private GameObject panelPause;

    private void Awake() {
        panelPause = transform.GetChild(0).gameObject;
        Cursor.visible = false;
    }

    void Update() {
        if (Input.GetButtonDown("Cancel") && !TimeManager.Paused) {
            TimeManager.Paused = true;
            panelPause.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void BtResume() {
        Cursor.visible = false;
        TimeManager.Paused = false;
        panelPause.SetActive(false);
    }

    public void BtRestart() {
        TimeManager.Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BtMainMenu() {
        TimeManager.Paused = false;
        SceneManager.LoadScene("Main");
    }
}
