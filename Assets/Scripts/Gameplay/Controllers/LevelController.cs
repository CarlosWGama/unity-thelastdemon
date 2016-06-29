using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour {

    /// <summary> Número de alvos para completar </summary>
    private int simbolos;
    public int Simbolos { get { return simbolos; } }

    /// <summary> Qual o Level atual </summary>
    public int levelAtual = 1;

    /// <summary> Música de Fundo </summary>
    public AudioClip BGM;

    /// <summary> Som de Fundo </summary>
    public AudioClip BGS;

    /// <summary> Qual a próxima fase </summary>
    public string proximaScene;
    
    [Header("Player")]
    [SerializeField]
    private int playerStamina;
    public int PlayerStamina { get { return playerStamina; } }

    [Header("Boss")]
    [SerializeField]
    private Sprite bossSprite;
    public Sprite BossSprite { get { return bossSprite; } }
    
    private int bossHP;
    public int BossHP { get { return bossHP; } }

    private Fade fade;

    void Awake() {
        bossHP = simbolos = FindObjectsOfType<Simbolo>().Length;
        fade = FindObjectOfType<Fade>();
        Tile.CanMove = true;
    }

    void Start() {
        fade.FadeIn();

        SoundManager.instance.PlayBGM(BGM);
        SoundManager.instance.PlayBGS(BGS);
    }

    void Update() {
        PlayerInfo.TimePlaying += TimeManager.DeltaTime;
    }

    public void EnterInSimbolo() {
        simbolos--;
        if (simbolos == 0) {
            PlayerInfo.CurrentLevel = levelAtual;
            fade.FadeOut();
            Invoke("LoadNextScene", 2f);
        }
    }

    public void LeaveSimbolo() {
        simbolos++;
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(proximaScene);
    }
}

