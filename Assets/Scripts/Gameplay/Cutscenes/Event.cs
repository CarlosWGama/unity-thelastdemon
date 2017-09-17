using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Event : MonoBehaviour {
    
    [SerializeField]
    private List<Dialogo> dialogos = new List<Dialogo>();

    private Dialogo currentDialogo;

    /// <summary> Linha Superior do WideScreen </summary>
    private Image BG;
    /// <summary> Linha Superior do WideScreen </summary>
    private Image lineTop;
    /// <summary> Linha Inferior do WideScreen </summary>
    private Image lineBottom;

    /// <summary> Linha Inferior do WideScreen </summary>
    private Image faceLeft;
    /// <summary> Linha Inferior do WideScreen </summary>
    private Image faceRight;
    /// <summary> Objeto onde será exibido o texto </summary>
    private Text text;
    /// <summary> Verifica se a cutscenermação está sendo executada </summary>
    private bool isPlaying = false;
    public bool IsPlaying { get { return isPlaying; } }
    
    /// <summary> Intervalo de um texto a outro para pular </summary>
    private float cooldownAction = 1f;

    public bool autoPlay = true;

    /// <summary> Serve para parar a Coroutine </summary>
    private IEnumerator coroutineTypeText;

    void Awake() {
        try {
            BG = transform.GetChild(0).GetComponent<Image>();
            lineTop = transform.GetChild(1).GetComponent<Image>();
            lineBottom = transform.GetChild(2).GetComponent<Image>();
            faceLeft = transform.GetChild(3).GetComponent<Image>();
            faceRight = transform.GetChild(4).GetComponent<Image>();
            text = transform.GetChild(5).GetComponent<Text>();
        }
        catch (UnityException ex) {
            Debug.Log(ex.Message);
        }
    }

    void Start() {
        if (autoPlay) Play();
    }

    void Update() {
        if (isPlaying) 
            Playing();
    }

    /// <summary> Avança </summary>
    private void Playing() {
        cooldownAction -= Time.deltaTime;

        //avança
        if (Input.anyKeyDown && cooldownAction <= 0) {
            cooldownAction = 1f;

            currentDialogo = GetNextDialogo();
            
            //Encerra a cutscenermação
            if (currentDialogo == null) { 
                Stop();
                return;
            }

            //Atualizar os textos e sons
            ShowEvent();
        }    
    }

    IEnumerator TypeText() {
        foreach (char letter in currentDialogo.Text.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    /// <summary>Atualiza todos os campos com as cutscenermações do evento </summary>
    private void ShowEvent() {
        if (coroutineTypeText != null)
            StopCoroutine(coroutineTypeText);
        //Atualiza o texto
        text.text = "";

        //Atualiza texto tipografado
        coroutineTypeText = TypeText();
        StartCoroutine(coroutineTypeText);

        if (currentDialogo.background != null) {
            BG.color = Color.white;
            BG.sprite = currentDialogo.background;
        } else {
            BG.color = new Color(1, 1, 1, 0);
        }

        // Rosto Esquerdo
        if (currentDialogo.Avatar1 != null) {
            faceLeft.enabled = true;
            faceLeft.sprite = currentDialogo.Avatar1;
            faceLeft.color = (currentDialogo.FocoAvatarEsquerda ? Color.white : new Color(1f, 1f, 1f, 0.2f));
        } else 
            faceLeft.enabled = false;
            
        // Rosto Direito
        if (currentDialogo.Avatar2 != null) {
            faceRight.enabled = true;
            faceRight.sprite = currentDialogo.Avatar2;
            faceRight.color = (!currentDialogo.FocoAvatarEsquerda ? Color.white : new Color(1f, 1f, 1f, 0.2f));
        } else 
            faceRight.enabled = false;
    }

    /// <summary> Inicia a cutscenermação </summary>
    public void Play() {
        currentDialogo = GetNextDialogo();
        if (currentDialogo != null) {
            TimeManager.SemiPaused = true;
            isPlaying = true;
            EnableWideScreen();
            text.enabled = true;
            text.color = Color.white;

            ShowEvent();
        }
#if UNITY_EDITOR
        else {
            Debug.Log("Não tem conteúdo adicionado");
        }
#endif
    }

    /// <summary> Encerra a cutscenermação </summary>
    public void Stop() {
        TimeManager.SemiPaused = false;
        isPlaying = false;
        DisableWideScreen();
        
        //Limpa os campos
        text.text = "";
        text.enabled = false;
        faceLeft.enabled = false;
        faceRight.enabled = false;
        dialogos = new List<Dialogo>(); //Limpa a lista
    }

    /// <summary> Método que busca a próxima cutscenermação </summary>
    /// <returns>Caso haja próxima cutscenermação, retorna a cutscenermação, do contrário retorna Null</returns>
    private Dialogo GetNextDialogo() {
        if (currentDialogo == null)   //Busca a primeira cutscene
            return dialogos[0];

        var index = dialogos.IndexOf(currentDialogo);
        index += 1;                 //Busca o id da próxima cutscene

        if (index >= dialogos.Count)  //Não tem mais cutscene
            return null;
        return dialogos[index];
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
