using UnityEngine;
using System.Collections;

public class Cutscene : ScriptableObject {

    public string Text {
        get {
            if (textID == null || textID.Equals(""))
                return "";
            return Language.GetText("CutScenes", textID);
        }
    }
    [SerializeField]
    private string textID;
    public Sprite Imagem;
    public int Duracao;
    public int FadeIn;
    public int FadeOut;
}
