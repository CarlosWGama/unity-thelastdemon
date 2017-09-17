using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary> Menu com as opções de Idioma e volume  </summary>
public class MenuOptions : MonoBehaviour {

    private bool moveIn = false;
    private bool moveOut = false;

    [SerializeField]
    ///<summary>Velocidade que menu se move ao entrar e sair</summary>
    private float speedMoving = 1000f;

    [SerializeField]
    ///<summary>Painel do menu principal</summary>
    private GameObject panelMainMenu;

    [Header("Bandeiras")]
    [SerializeField]
    ///<summary>Lista das imagens das bandeiras</summary>
    private List<Sprite> flags;

    [SerializeField]
    ///<summary>Imagem atual da bandeira</summary>
    private Image flag;

    [Header("Áudios")]
    [SerializeField]
    ///<summary>Background Music</summary>
    private Slider BGM;
    [SerializeField]
    ///<summary>Background Sound</summary>
    private Slider BGS;
    [SerializeField]
    ///<summary>Sound Effect</summary>
    private Slider SE;

    /// <summary> Movimentação do Objeto no Canvas</summary>
    private RectTransform rectTransform;

    /// <summary> Idioma atual selecionado </summary>
    private Language.Languages currentLanguage;

    void Awake () {
        rectTransform = GetComponent<RectTransform>();
    }
	
	void Update () {
        //Entra em cena
	/*    if (moveIn) {
            rectTransform.Translate(Vector3.right * speedMoving * TimeManager.DeltaTimeRunning);
            if (rectTransform.localPosition.x >= 0) {
                var position = rectTransform.localPosition;
                position.x = 0;
                rectTransform.localPosition = position;
                moveIn = false;
            }
        }

        //Sai de cena
        if (moveOut) {
            rectTransform.Translate(-Vector3.right * speedMoving * TimeManager.DeltaTimeRunning);
            if (rectTransform.localPosition.x <= -600) {
                var position = rectTransform.localPosition;
                position.x = -600;
                rectTransform.localPosition = position;
                moveOut = false;
                FindObjectOfType<SoundManager>().UpdateVolume();
                Language.UpdateLanguage();
                panelMainMenu.SetActive(true);      //Habilita o menu principal
                gameObject.SetActive(false);        //Desabilita o menu atual
            }
        }*/
    }

    void OnEnable() {
        //Atualiza campos
        if (PlayerPrefs.HasKey("Language")) {
            currentLanguage = (Language.Languages)PlayerPrefs.GetInt("Language");
            flag.sprite = flags[(int)currentLanguage];
        }

        /* if (PlayerPrefs.HasKey("BGM")) 
             BGM.value = PlayerPrefs.GetFloat("BGM") * 100;


         if (PlayerPrefs.HasKey("BGS"))
             BGS.value = PlayerPrefs.GetFloat("BGS") * 100;


         if (PlayerPrefs.HasKey("SE"))
             SE.value = PlayerPrefs.GetFloat("SE") * 100;



         //movimento
         var position = rectTransform.localPosition;
         position.x = -600;
         rectTransform.localPosition = position;
         moveIn = true;

         */
    }

    public void ButtonCancel() {
        moveOut = true;
    }

    public void ButtonConfirm() {
        moveOut = true;

        PlayerPrefs.SetInt("Language", (int)currentLanguage); //Idioma
        /*PlayerPrefs.SetFloat("BGM", BGM.value/100);
        PlayerPrefs.SetFloat("BGS", BGS.value / 100);
        PlayerPrefs.SetFloat("SE", SE.value / 100);*/
    }

    public void ButtonLanguage() {
        currentLanguage = (currentLanguage == Language.Languages.PT_BR ? Language.Languages.EN : Language.Languages.PT_BR);
        flag.sprite = flags[(int)currentLanguage];
        PlayerPrefs.SetInt("Language", (int)currentLanguage); //Idioma
        Language.UpdateLanguage();
    }
}
