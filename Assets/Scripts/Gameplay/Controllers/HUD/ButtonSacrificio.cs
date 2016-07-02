using UnityEngine;
using UnityEngine.UI;

public class ButtonSacrificio : MonoBehaviour { 

    private Text texto;

	void Awake () {
        texto = GetComponentInChildren<Text>();
        TextoNormal();
	}

    public void TextoNormal() {
        texto.color = Color.white;
        texto.text = "Vidas x" + PlayerInfo.Lives;
    }

    public void TextoSacrificio() {
        texto.color = Color.red;
        texto.text = "Sacrificar";
    }

    public void Sacrificar() {
        PlayerInfo.UseLife();
    }
}
