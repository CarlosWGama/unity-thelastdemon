using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossName : MonoBehaviour {

    private Text texto;

	
	void Awake () {
        texto = GetComponent<Text>();
	}
	
	void Start() {
        texto.text = FindObjectOfType<LevelController>().BossName;
    }

}
