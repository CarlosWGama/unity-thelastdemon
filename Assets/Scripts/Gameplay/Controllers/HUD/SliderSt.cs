using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class SliderSt : MonoBehaviour {

    protected int totalSt;
    protected float currentSt;
    public float CurrentSt { get { return currentSt; } }
    protected Slider slider;
    protected Text texto;
    [SerializeField]
    protected float speedRecover = 2f;

    protected virtual void Start() {
        //currentSt = totalSt = FindObjectOfType<LevelController>().PlayerStamina;
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue = currentSt;
        texto = GetComponentInChildren<Text>();
    }
	
	protected virtual void Update () {
        slider.value = currentSt;
        texto.text = "St " + (int) slider.value + "/" + slider.maxValue;

        currentSt += TimeManager.DeltaTime * speedRecover;
        if (currentSt > totalSt) currentSt = totalSt;
    }

    /// <summary>
    /// Usa Stamina
    /// </summary>
    /// <param name="stamina">Quantidade de Stamina usada</param>
    /// <returns>Retorna true caso tenha estamina suficiente</returns>
    public bool Use(float stamina) {
        if (currentSt >= stamina) { 
            currentSt -= stamina;
            if (currentSt <= 0) 
                currentSt = 0;
            return true;
        }
        return false;
    }
}
