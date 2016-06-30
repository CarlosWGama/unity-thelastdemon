using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Armazena as informações do Jogador entre as diferentes fases
/// </summary>
public class PlayerInfo {

    /// <summary>
    /// Guarda informação do áudio do jogador
    /// </summary>
    public static bool AudioIsOn = true;

    /// <summary>
    /// Guarda informação do tempo gasto pelo jogador
    /// </summary>
    public static float TimePlaying = 0;

    /// <summary>
    /// Exibe o tempo jogador, formatado
    /// </summary>
    public static string TimePlayingFormatted { get { return Mathf.Floor(TimePlaying / 60) + ":" + (TimePlaying % 60).ToString("00"); } }

    /// <summary>
    /// Guarda informação do level completado pelo jogador
    /// </summary>
    public static int CurrentLevel = 0;

    /// <summary>
    /// Total de vidas do jogador
    /// </summary>
    public static int Lives = 5;

    /// <summary>
    /// HP atual do personagem
    /// </summary>
    public static int HP = 5;

    public static void ResetaDados() {
        TimePlaying = 0;
        CurrentLevel = 0;
        Lives = 5;
        RestoreHP();
    }

    public static void UseLife() {
        RestoreHP();
        Lives--;

        if (Lives <= 0) 
            SceneManager.LoadScene("GameOver");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void RestoreHP() {
        HP = 5;
    }
}
