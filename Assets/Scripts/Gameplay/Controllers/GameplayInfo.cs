using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe que Guarda o Progreesso do Modo História
/// </summary>
public class GameplayInfo {

    [Serializable]
    public class CheckPoint {
        public int MaxLevelUnlock;
        public int LastStageUnlock;
    }

    /// <summary> Guarda os dados do checkpoint </summary>
    public static CheckPoint Checkpoint {
        get { return checkpoint; }
        set {
            checkpoint = value;
            maxLevelUnlock = checkpoint.MaxLevelUnlock;
            lastStageUnlock = checkpoint.LastStageUnlock;
        }
    }
    private static CheckPoint checkpoint = new CheckPoint();

    /// <summary> Informa o último level que está desbloqueado </summary>
    public static int MaxLevelUnlock {
        get { return maxLevelUnlock; }
        set {
            maxLevelUnlock = (value > maxLevelUnlock ? value : maxLevelUnlock);
            checkpoint.MaxLevelUnlock = maxLevelUnlock;
        }
    }
    /// <summary> Informa o level estágio que está desbloqueado </summary>
    public static int maxLevelUnlock = 1;

    /// <summary> Informa o último estágio que está desbloqueado </summary>
    public static int lastStageUnlock = 1;
    /// <summary> Informa o último estágio que está desbloqueado </summary>
    public static int LastStageUnlock {
        get { return lastStageUnlock; }
        set {
            lastStageUnlock = (value > lastStageUnlock ? value : lastStageUnlock);
            checkpoint.LastStageUnlock = lastStageUnlock;
        }
    }
    
    /// <summary>
    /// Continua o jogo do ultimo cenário válido
    /// </summary>
    public static void OpenLastStage() {
        SaveLoad.Load();
        PlayerInfo.ResetStatus();

        // Carrega a primeira scene do estágio atual
        var sceneName = "Level_" + checkpoint.MaxLevelUnlock + "_0D";
        if (!SceneManager.GetSceneByName(sceneName).IsValid())
            sceneName = "Level_" + checkpoint.MaxLevelUnlock + "_1";
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Salva o progresso do jogo
    /// </summary>
    public static void SaveProgress() {
        SaveLoad.Save();
    }
}

