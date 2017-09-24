using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Armazena as informações do Jogador entre as diferentes fases
/// </summary>
[Serializable]
public class PlayerInfo {

    /// <summary>
    /// Guarda informação do áudio do jogador
    /// </summary>
    public static bool AudioIsOn = true;

    /// <summary>
    /// Total de vidas do jogador
    /// </summary>
    public static int Lives = 3;

    /// <summary>
    /// HP atual do personagem
    /// </summary>
    public static int HP = 10;

    public static void ResetStatus() {
        Lives = 3;
        RestoreHP();
    }

    public static void UseLife() {
        RestoreHP();
        Lives--;

        if (Lives <= 0) 
            GameplayInfo.OpenLastStage();
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void RestoreHP() {
        HP = 10;
    }
}
