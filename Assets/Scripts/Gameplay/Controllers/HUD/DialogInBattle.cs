using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInBattle : MonoBehaviour {


    public enum Duration { SHORT = 4, LONG = 8 };

    /// <summary> Panel do Player </summary>
    private GameObject playerBalloon;
    /// <summary> Text do Player </summary>
    private Text playerText;
    /// <summary> Panel do Boss </summary>
    private GameObject bossBalloon;
    /// <summary> Text do Boss </summary>
    private Text bossText;


    private static DialogInBattle instance;
    public static DialogInBattle Instance { get { return instance; }  }

    void Awake() {
        instance = this;
        playerBalloon = transform.GetChild(0).gameObject;
        playerText = playerBalloon.GetComponentInChildren<Text>();
        bossBalloon = transform.GetChild(1).gameObject;
        bossText = bossBalloon.GetComponentInChildren<Text>();
    }

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Abre o Balão de Dialogo do Player
    /// </summary>
    /// <param name="dialogID">ID do texto</param>
    /// <param name="duration">Duração do texto (SHORT 2s | LONG = 4s)</param>
    public void Player(string dialogID, Duration duration = Duration.SHORT) {
        CancelInvoke("DisablePlayer");
        var text = Language.GetText("Balloons", dialogID);
        playerText.text = ReplaceTags(text);
        playerBalloon.SetActive(true);
        Invoke("DisablePlayer", (float)duration);
    }

    /// <summary> Fecha o balão do player </summary>
    private void DisablePlayer() {
        playerBalloon.SetActive(false);
    }

    /// <summary>
    /// Abre o Balão de Dialogo do Boss
    /// </summary>
    /// <param name="dialogID">ID do texto</param>
    /// <param name="duration">Duração do texto (SHORT 4s | LONG = 8s)</param>
    public void Boss(string dialogID, Duration duration = Duration.SHORT) {
        CancelInvoke("DisableBoss");
        var text = Language.GetText("Balloons", dialogID);
        bossText.text = ReplaceTags(text);
        bossBalloon.SetActive(true);
        Invoke("DisableBoss", (float)duration);
    }

    /// <summary> Fecha o balão do player </summary>
    private void DisableBoss() {
        bossBalloon.SetActive(false);
    }

    /// <summary>
    /// Troca possíveis tags no texto
    /// </summary>
    /// <param name="text">Texto que irá ser atualizado</param>
    /// <returns>Texto atualizado</returns>
    private string ReplaceTags(string text) {
        text = text.Replace("[user]", System.Environment.UserName);
        return text;
    }
}
