using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//<summary>Classe que controla a cena com a introdutoria com a logo do jogo</summary>
public class LogoIapois : MonoBehaviour {

    [SerializeField]
    private Image logo;

    [Header("Tempo")]
    [SerializeField]
    private float fadeIn;           //Duração do Fade In
    private float fadeInFullTime;   //Tempo do Fade In ao todo

    [SerializeField]
    private float duration;         //Duração da Logo em exibição

    [SerializeField]
    private float fadeOut;          //Duração do fade out
    private float fadeOutFull;      //Tempo do Fade Out ao todo

    void Awake() {
        fadeInFullTime = fadeIn;
        fadeOutFull = fadeOut;
    }


    void Update () {

        var color = logo.color;

        if (fadeIn > 0) {
            fadeIn -= TimeManager.DeltaTimeRunning;
            color.a = (1f - ((fadeIn * 100) / fadeInFullTime) / 100);

        } else if (duration > 0) {
            duration -= TimeManager.DeltaTimeRunning;
            color.a = 1f;
        } else if (fadeOut > 0) {
            fadeOut -= TimeManager.DeltaTimeRunning;
            color.a = (((fadeOut * 100) / fadeOutFull) / 100);
        } else
            SceneManager.LoadScene("Main");
        
        logo.color = color;
	}
}
