﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Event : MonoBehaviour {
    
    [SerializeField]
    private List<Cutscene> cutscenes = new List<Cutscene>();

    private Cutscene currentCutscene;

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

            currentCutscene = GetNextCutscene();
            
            //Encerra a cutscenermação
            if (currentCutscene == null) { 
                Stop();
                return;
            }

            //Atualizar os textos e sons
            ShowEvent();
        }    
    }

    IEnumerator TypeText() { 
        foreach (char letter in currentCutscene.Texto.ToCharArray()) {
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

        // Rosto Esquerdo
        if (currentCutscene.Avatar1 != null) {
            faceLeft.enabled = true;
            faceLeft.sprite = currentCutscene.Avatar1;
            faceLeft.color = (currentCutscene.FocoAvatarEsquerda ? Color.white : new Color(1f, 1f, 1f, 0.2f));
        } else 
            faceLeft.enabled = false;
            
        // Rosto Direito
        if (currentCutscene.Avatar2 != null) {
            faceRight.enabled = true;
            faceRight.sprite = currentCutscene.Avatar2;
            faceRight.color = (!currentCutscene.FocoAvatarEsquerda ? Color.white : new Color(1f, 1f, 1f, 0.2f));
        } else 
            faceRight.enabled = false;
    }

    /// <summary> Inicia a cutscenermação </summary>
    public void Play() {
        currentCutscene = GetNextCutscene();
        if (currentCutscene != null) {
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
        cutscenes = new List<Cutscene>(); //Limpa a lista
    }

    /// <summary> Método que busca a próxima cutscenermação </summary>
    /// <returns>Caso haja próxima cutscenermação, retorna a cutscenermação, do contrário retorna Null</returns>
    private Cutscene GetNextCutscene() {
        if (currentCutscene == null)   //Busca a primeira cutscene
            return cutscenes[0];

        var index = cutscenes.IndexOf(currentCutscene);
        index += 1;                 //Busca o id da próxima cutscene

        if (index >= cutscenes.Count)  //Não tem mais cutscene
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
