using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

// <summary>Classe responsável por gerar Cutscenes </summary>
public class CutscenePlayer : MonoBehaviour {

    //Current Scene
    private Cutscene currentCutscene;        //Trabalha na Cutscene atual
    public Cutscene CurrentCutscene {
        get { return currentCutscene;  }
    }

    [Header("Opções de Cutscene")]
    //Cenas
    [SerializeField]
    private List<Cutscene> cutscenes = new List<Cutscene>();
    public List<Cutscene> Cutscenes {
        get { return cutscenes;  }
    }

    //Configurações
    [Header("Config")]
    [SerializeField]
    private bool playOnAwake;                   //Executa quando objeto é criado
    public bool PlayOnAwake {
        get { return playOnAwake; }
        set { playOnAwake = value; }
    }

    [SerializeField]
    private bool canSkip = true;                //Pode pular a scene;
    public bool CanSkip {
        get { return canSkip; }
        set { canSkip = value;  }

    }

    [SerializeField]
    private string trocarSceneQuandoFinaliza;

    private bool isPlaying;                     //Executa a cutscene
    public bool IsPlaying { get { return isPlaying; } }

    private float timerFade;                    //Contador da duração do Fade
    private float timerScene;                   //Contador da duração da cena
    
    private bool trySkip = false;               //Tentou pular a scene;
    private bool sceneIsFinished = false;       //A cena tem encerrado

    /*[SerializeField]
    private Sprite defaultSprite;*/

    //Objects
    private Image BG;
    private Image lineTop;
    private Image lineBottom;
    private Image image;
    private Text text;
    private Text skipCutScene;

    void Awake() {
        try {
            BG = transform.GetChild(0).GetComponent<Image>();
            image = transform.GetChild(1).GetComponent<Image>();
            lineTop = transform.GetChild(2).GetComponent<Image>();
            lineBottom = transform.GetChild(3).GetComponent<Image>();
            skipCutScene = transform.GetChild(4).GetComponent<Text>();
            text = transform.GetChild(5).GetComponent<Text>();
        } catch (UnityException ex) {
            Debug.Log(ex.Message);
        }

        if (playOnAwake)
            Play();
    }

    // <summary>Realiza a cutscene </summary>
    void Update () {
        if (isPlaying) {
            ///// Pula CutScene //////
            if (canSkip && Input.anyKeyDown) {
                if (!trySkip) { 
                    trySkip = true;
                    skipCutScene.enabled = true;
                } else { 
                    Stop();
                    return;
                }
            }
            
            ///// Executa a CutScene /////
            
            //Busca o primeiro elemento
            if (currentCutscene == null) 
                currentCutscene = GetNextScene();

            //Troca o texto e imagem
            //image.sprite = (currentCutscene.Imagem != null ? currentCutscene.Imagem : defaultSprite);
            image.sprite = currentCutscene.Imagem;
            text.text = currentCutscene.Texto;
            

            //Realiza o Fade In/Out
            var timeFade = (sceneIsFinished ? currentCutscene.FadeOut : currentCutscene.FadeIn);
            if (timerFade < timeFade) {    //Fade
                timerFade += TimeManager.DeltaTimeRunning;
                var percentage = (timerFade * 100 / timeFade) / 100;
                percentage = Mathf.Clamp(percentage, 0f, 1f);
                percentage = (sceneIsFinished ? 1f - percentage : percentage);

                var colorImage = image.color;
                colorImage.a = percentage;
                image.color = colorImage;

                var colorText = text.color;
                colorText.a = percentage;
                text.color = colorText;
            } else {                     

                //Mante a Scene enquanto de acordo com o seu tempo de duração
                if (!sceneIsFinished) {
                    if (timerScene <= currentCutscene.Duracao)   //Scene Ativa
                        timerScene += TimeManager.DeltaTimeRunning;
                    else {                                      //Realizar o Fade Out
                        sceneIsFinished = true;
                        timerFade = 0f;         //Realizar o FadeOut
                    }
                } else {   //Troca de Scene
                    currentCutscene = GetNextScene();
                    if (currentCutscene == null)
                        Stop();
                }
            }
        }
	}

    // <summary>Inicia a Cutscene</summary>
    public void Play() {
        TimeManager.Paused = true;
        isPlaying = true;

        //Ativa CutScene
        BG.enabled = true;
        EnableWideScreen();
        image.enabled = true;
        text.enabled = true;
    }

    // <summary>Para a Cutscene</summary>
    public void Stop() {
        TimeManager.Paused = false;
        isPlaying = false;

        //Desativa CutScene
        BG.enabled = false;
        DisableWideScreen();
        image.enabled = false;
        text.enabled = false;
        skipCutScene.enabled = false;

        if (!trocarSceneQuandoFinaliza.Equals("")) 
            SceneManager.LoadScene(trocarSceneQuandoFinaliza);
    }

    // <summary>Reinicia a cutscene</summary>
    public void Reset() {
        currentCutscene = null;
    }

    // <summary>Remove todos as cutscenes da Cutscene</summary>
    public void ClearCutscenes() {
        cutscenes = new List<Cutscene>();
    }

    // <summary>Adiciona nova Scene</summary>
    public void AddScene(Cutscene scene) {
        cutscenes.Add(scene);
    }

    // <summary>Busca próxima scene a ser tocada</summary>
    private Cutscene GetNextScene() {
        sceneIsFinished = false;    
        timerFade = 0f;
        timerScene = 0f;

        if (currentCutscene == null)   //Busca a primeira Scene
            return cutscenes[0];


        var index = cutscenes.IndexOf(currentCutscene);
        index += 1;                 //Busca o id da próxima scene

        if (index >= cutscenes.Count)  //Não tem mais scene
            return null; 

        return cutscenes[index];
    }

    /// <summary> Habilita as linhas WideScreen </summary>
    public void EnableWideScreen() {
        lineTop.enabled = true;
        lineBottom.enabled = true;
    }

    /// <summary> Desabilita as linhas WideScreen </summary>
    public void DisableWideScreen() {
        lineTop.enabled = false;
        lineBottom.enabled = false;
    }
}
