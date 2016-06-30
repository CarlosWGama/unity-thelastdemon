using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script usado na animação do Demonio surgindo na intro do inicio
/// </summary>
public class Demon : MonoBehaviour {

    /// <summary> Imagem do Demonio </summary>
    private Image demon;
    /// <summary> Imagem das chamas </summary>
    private Image flame;

    /// <summary> Tempo para o demonio surgir </summary>
    [SerializeField]
    private float delay;

    /// <summary> Duração do efeito surgindo </summary>
    [SerializeField]
    private float fadeIn;

    /// <summary> Duração do efeito desaparecendo </summary>
    [SerializeField]
    private float fadeOut;

    /// <summary> Duração do tempo </summary>
    [SerializeField]
    private float duracao;

    /// <summary> O quanto será clareado </summary>
    [Range(0, 1)]
    [SerializeField]
    private float opacidade;

    private bool startFadeOut;

    /// <summary> Controlador do efeito de Fade </summary>
    private float timerFade;

    /// <summary> Controlador do efeito de duração </summary>
    private float timerDuracao;

    void Awake () {
        demon = GetComponent<Image>();
        flame = transform.GetChild(0).GetComponent<Image>();
        Debug.Log(flame.name);
	}
	
	
	void Update () {
        
        if (delay >= 0) {
            delay -= TimeManager.DeltaTimeRunning;
        } else {
            
            var timeFade = (startFadeOut ? fadeOut : fadeIn);
            
            if (timerFade <= timeFade) {    //Fade
                timerFade += TimeManager.DeltaTimeRunning;
                var percentage = (timerFade * opacidade / timeFade);
                percentage = Mathf.Clamp(percentage, 0f, 1f);
                percentage = (startFadeOut ? opacidade - percentage : percentage);
                Debug.Log(percentage);
                //Demon
                var colorImage = demon.color;
                colorImage.a = percentage;
                demon.color = colorImage;

                //Fogo
                colorImage = flame.color;
                colorImage.a = percentage;
                flame.color = colorImage;
            } else {

                //Mante a Scene enquanto de acordo com o seu tempo de duração
                if (!startFadeOut) {
                    if (timerDuracao <= duracao)   //Scene Ativa
                        timerDuracao += TimeManager.DeltaTimeRunning;
                    else {                                      //Realizar o Fade Out
                        startFadeOut = true;
                        timerFade = 0f;         //Realizar o FadeOut
                    }
                }
                else
                    Destroy(gameObject);
            }
        }
    }


}
