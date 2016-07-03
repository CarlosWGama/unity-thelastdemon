using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderSt : MonoBehaviour {

    private int totalSt;
    private int currentSt;
    private Slider slider;
    private Text texto;
    private bool hasStamina = false;
    public bool HasStamina { get { return hasStamina; } }

    void Start() {
        currentSt = totalSt = FindObjectOfType<LevelController>().PlayerStamina;
        hasStamina = true;
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue = currentSt;
        texto = GetComponentInChildren<Text>();
    }
	
	void Update () {
        slider.value = currentSt;
        texto.text = "St " + slider.value + "/" + slider.maxValue;
    }

    public void Use() {
        currentSt--;
        if (currentSt <= 0) {
            currentSt = 0;
            hasStamina = false;
        }
            
    }
}
