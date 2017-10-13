using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

    /// <summary> Número de alvos para completar </summary>
    private int simbolos;
    public int Simbolos { get { return simbolos; } }

    /// <summary> Qual o Level atual </summary>
    public int levelAtual = 1;

    /// <summary> Estágio a qual pertence esse cenário </summary>
    public int stageAtual = 1;

    /// <summary> Música de Fundo </summary>
    public AudioClip BGM;

    /// <summary> Som de Fundo </summary>
    public AudioClip BGS;

    /// <summary> Qual a próxima fase </summary>
    public string proximaScene = "Level_0_0";
    
    [Header("Player")]
    [SerializeField]
    private bool resetStatusOnFinish = false;

    /// <summary> Falas do Player durante a fase </summary>
    public List<string> RandomTextsPlayer = new List<string>();
    /// <summary> Pega o texto Atual do Player </summary>
    private int currentTextPlayer = 0;
    /// <summary> Atraso para começar as falas </summary>
    public float DelayPlayer = 2f;
    /// <summary> Tempo para a próxima fala </summary>
    public float RepeatPlayer = 8f;

    [Header("Boss")]
    [SerializeField]
    private Sprite bossSprite;
    public Sprite BossSprite { get { return bossSprite; } }

    private int bossHP;
    public int BossHP { get { return bossHP; } }

    private bool firstHit = true;
    /// <summary> Fala do boss ao receber o primeiro dano </summary>
    public string TextOnHit;
    /// <summary> Falas do Boss durante a fase </summary>
    public List<string> RandomTextsBoss = new List<string>();
    /// <summary> Pega o texto Atual do Boss </summary>
    private int currentTextBoss = 0;
    /// <summary> Atraso para começar as falas </summary>
    public float DelayBoss = 3f;
    /// <summary> Tempo para a próxima fala </summary>
    public float RepeatBoss = 8f;

    /// <summary> Nome do Boss </summary>
    [SerializeField]
    private string bossName;
    public string BossName { get { return bossName; } }

    private Fade fade;

    void Awake() {
        bossHP = simbolos = FindObjectsOfType<Simbolo>().Length;
        fade = FindObjectOfType<Fade>();
        Tile.CanMove = true;
    }

    void Start() {
        fade.FadeIn();

        //Audio
        SoundManager.instance.PlayBGM(BGM);
        SoundManager.instance.PlayBGS(BGS);

        //Salva o progresso
        GameplayInfo.MaxLevelUnlock = levelAtual;
        GameplayInfo.LastStageUnlock = stageAtual;
        GameplayInfo.SaveProgress();

        //Dialogos
        if (RandomTextsPlayer.Count > 0) InvokeRepeating("TextPlayer", DelayPlayer, RepeatPlayer);
        if (RandomTextsBoss.Count > 0) InvokeRepeating("TextBoss", DelayBoss, RepeatBoss);

    }

    void LateUpdate() {
        if (simbolos == 0) {
            fade.FadeOut();

            if (resetStatusOnFinish) PlayerInfo.ResetStatus();
            Invoke("LoadNextScene", 2f);
        }
    }

    public void EnterInSimbolo() {
        simbolos--;
        if (firstHit && !TextOnHit.Equals("")) {
            firstHit = false;
            DialogInBattle.Instance.Boss(TextOnHit);
        }
    }

    public void LeaveSimbolo() {
        simbolos++;
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(proximaScene);
    }

    /// <summary>
    /// Invoca os textos dos boss de tempo em tempo
    /// </summary>
    private void TextPlayer() {
        if (!TimeManager.Paused) { 
            DialogInBattle.Instance.Player(RandomTextsPlayer[currentTextPlayer]);
            currentTextPlayer++;
            if (currentTextPlayer == RandomTextsPlayer.Count)
                CancelInvoke("TextPlayer");
        }
    }

    /// <summary>
    /// Invoca os textos dos boss de tempo em tempo
    /// </summary>
    private void TextBoss() {
        if (!TimeManager.Paused) {
            DialogInBattle.Instance.Boss(RandomTextsBoss[currentTextBoss]);
            currentTextBoss++;
            if (currentTextBoss == RandomTextsBoss.Count)
                CancelInvoke("TextBoss");
        }
    }
}

