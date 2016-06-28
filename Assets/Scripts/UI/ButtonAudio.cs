using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Botão que habilita e desabilita o Áudio do jogo
/// </summary>
public class ButtonAudio : MonoBehaviour {

    [SerializeField]
    /// <summary>Sprite do Botão ativado</summary>
    private Sprite iconOn;

    [SerializeField]
    /// <summary>Sprite do Botão desativado</summary>
    private Sprite iconOff;

    /// <summary>Guarda informação do estatus do áudio</summary>
    private bool isOn;

    /// <summary>UI do botão</summary>
    private Image icon;

    void Awake() {
        icon = GetComponent<Image>();
        isOn = PlayerInfo.AudioIsOn;
        icon.sprite = (isOn ? iconOn : iconOff);
    }

    /// <summary> Habilita/Desabilita áudio </summary>
	public void ToggleAudio() {
        PlayerInfo.AudioIsOn = isOn = !isOn;
        icon.sprite = (isOn ? iconOn : iconOff);
    }
}
