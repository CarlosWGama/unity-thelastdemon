using UnityEngine;

/// <summary> Classe responsavel pelo controle do Tempo do Jogo </summary>
public static class TimeManager {

    /// <summary> Pausa o jogo </summary>
    private static bool paused = false;
    public static bool Paused {
        get { return paused;  }
        set {
            paused = value;
            semiPaused = false;
        }
    }
    
    /// <summary> Pausa o jogo, mas animações e audios não são afetados </summary>
    public static bool semiPaused;
    public static bool SemiPaused {
        get { return semiPaused; }
        set {
            paused = value;
            semiPaused = value;
        }
    }


    /// <summary> Tempo afetado pelo pause </summary>
    public static float DeltaTime {
        get { return (Paused ? 0f : Time.deltaTime); }
    }

    /// <summary> Tempo não afetado pelo pause </summary>
    public static float DeltaTimeRunning {
        get { return Time.deltaTime; }
    }


}
