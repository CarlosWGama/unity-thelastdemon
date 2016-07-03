using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditosFinal : MonoBehaviour {

    /// <summary>
    /// Música tocada
    /// </summary>
    [SerializeField]
    private AudioClip BGM;

    /// <summary>
    /// Qual é a scene que será carregada ao compeltar  música
    /// </summary>
    [SerializeField]
    private string proximaScene;

    /// <summary>
    /// Tempo para permanecer na scene
    /// </summary>
    private float time;
    
    /// <summary>
    /// Campos de texto
    /// </summary>
    [SerializeField]
    private Text texto;

    /// <summary>
    /// Até onde o texto deve subir
    /// </summary>
    public Vector3 target;

    /// <summary>
    /// Velocidade com que a tela sobe
    /// </summary>
    public float velocidade;

    void Start () {
        time = BGM.length;
        SoundManager.instance.PlayBGM(BGM);
	}
	
	void Update () {
        time -= TimeManager.DeltaTime;
        if (time <= 0) 
            SceneManager.LoadScene(proximaScene);
        else 
            texto.rectTransform.localPosition = Vector3.MoveTowards(texto.rectTransform.localPosition, target, velocidade * TimeManager.DeltaTime);
	}
}
