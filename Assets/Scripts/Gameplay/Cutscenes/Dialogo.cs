using UnityEngine;
using System.Collections;

public class Dialogo : ScriptableObject {

    public string Text {
        get {
            if (textID == null || textID.Equals(""))
                return "";
            return Language.GetText("Dialog", textID);
        }
    }
    public string textID;
    public Sprite Avatar1;
    public Sprite Avatar2;
    public Sprite background;
    public bool FocoAvatarEsquerda = true; //Qual dos rostos está falando
}
