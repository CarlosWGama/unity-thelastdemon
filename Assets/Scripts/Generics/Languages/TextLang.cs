using UnityEngine;
using UnityEngine.UI;
using System;

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
    }

    void Start()
    {
        UpdateText();
    }

    void OnEnable() {
        UpdateText();
    }

    public void UpdateText() {
        try { 
            textUI.text = Language.GetText(type, ID);
        } catch (Exception e) {
#if UNITY_EDITOR
            Debug.LogError(e.Message);
            Debug.LogError("Type " + type);
            Debug.LogError("ID " + ID);
#endif
        }
    }

}
