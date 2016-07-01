using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NivelAtual : MonoBehaviour {

    void Start() {
        GetComponent<Text>().text = "Nível " + FindObjectOfType<LevelController>().levelAtual;
    }
}
