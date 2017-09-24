using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    private int playerStamina;
    public int PlayerStamina { get { return playerStamina; } }

    [SerializeField]
    private bool resetStatusOnFinish = false;

    [Header("Boss")]
    [SerializeField]
    private Sprite bossSprite;
    public Sprite BossSprite { get { return bossSprite; } }
    
    private int bossHP;
    public int BossHP { get { return bossHP; } }

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
    }

    public void LeaveSimbolo() {
        simbolos++;
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(proximaScene);
    }
}

