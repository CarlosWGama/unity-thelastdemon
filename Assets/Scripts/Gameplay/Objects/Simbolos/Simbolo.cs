using UnityEngine;

public class Simbolo : MonoBehaviour, ISimbolo {

    private LevelController levelController;
    private SpriteRenderer imagem;

    /// <summary> Verifica se está surgindo ou desaparecendo </summary>
    private bool isFadeIn = false;

    /// <summary> Duração de um fade in e ou </summary>
    [SerializeField]
    private float duration = 1f;

    /// <summary> Controlador do efeito </summary>
    private float timeController = 0f;

    void Awake() {
        imagem = GetComponent<SpriteRenderer>();
    }

    void Start() {
        levelController = FindObjectOfType<LevelController>();
    }


    void Update() {
        var color = imagem.color;
        timeController += TimeManager.DeltaTime;
        
        var percentage = ((timeController * 100) / duration) / 100;
        percentage = Mathf.Clamp(percentage, 0, 1f);
        

        if (isFadeIn) color.a = (percentage);   //Fade IN
        else color.a = (1f - percentage);        //Fade Out

        if (percentage >= 1) {
            isFadeIn = !isFadeIn; //Toggle
            timeController = 0f;
        }
        

        imagem.color = color;
    }

	void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Vela")) {
            levelController.EnterInSimbolo();
        }
    }

    void OnTriggerExit2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Vela")) {
            levelController.LeaveSimbolo();
        }
    }
}
