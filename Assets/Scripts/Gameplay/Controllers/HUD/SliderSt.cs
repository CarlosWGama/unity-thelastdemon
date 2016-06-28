using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderSt : MonoBehaviour {

    private int totalSt;
    private int currentSt;
    private Slider slider;
    private bool hasStamina = false;
    public bool HasStamina { get { return hasStamina; } }

    void Start() {
        currentSt = totalSt = FindObjectOfType<LevelController>().PlayerStamina;
        hasStamina = true;
        slider = GetComponent<Slider>();
        slider.value = slider.maxValue = currentSt;
    }
	
	void Update () {
        slider.value = currentSt;
    }

    public void Use() {
        currentSt--;
        if (currentSt <= 0) {
            currentSt = 0;
            hasStamina = false;
        }
            
    }
}
