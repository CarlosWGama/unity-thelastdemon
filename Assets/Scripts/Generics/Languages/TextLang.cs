using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLang : MonoBehaviour {

    /// <summary> Campo com o texto </summary>
    private Text textUI;

    [SerializeField]
    /// <summary>Nome do arquivo com o texto </summary>
    private string type = "GUI";

    [SerializeField]
    /// <summary> ID do item </summary>
	private string ID;

    void Awake() {
        textUI = GetComponent<Text>();
        UpdateText();
    }

    void OnEnable() {
        UpdateText();
    }

    public void UpdateText() {
        textUI.text = Language.GetText(type, ID);
    }

}
