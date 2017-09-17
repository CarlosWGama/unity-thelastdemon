using UnityEngine;
using System.IO;
using System.Xml;

public static class Language {

    public enum Languages {
        PT_BR = 0,
        EN = 1
    }

    public static string language = "EN";
    public static string pathLanguage = "Languages";

    /// <summary>
    /// Busca o texto
    /// </summary>
    /// <param name="type">Nome do arquivo XML</param>
    /// <param name="id">ID do texto no arquivo</param>
    /// <returns>Texto traduzido</returns>
    public static string GetText(string type, string id) {
        //Busca o arquivo
        var xmlText = Resources.Load(pathLanguage + "/" + language + "/" + type, typeof(TextAsset)) as TextAsset;
        XmlReader xml = XmlReader.Create(new StringReader(xmlText.text));
        
        //Busca no grupo
        while(xml.Read()) {
            if (xml.GetAttribute("id") == id) 
                return xml.GetAttribute("text");
        }
#if UNITY_EDITOR
        Debug.Log("Texto não encontrado. Tipo: " + type + " | ID: " + id);
#endif
        return "";
    }

    /// <summary>
    /// Atualiza/Inicia as configurações de qual lingua está setada
    /// </summary>
    public static void RefreshLanguague() {
        if (PlayerPrefs.HasKey("Language")) {
            switch (PlayerPrefs.GetInt("Language")) {
                case (int)Languages.EN: language = "EN"; break;
                case (int)Languages.PT_BR: language = "PT_BR"; break;
            }
        }
    }

    /// <summary>
    /// Atualiza a configuração de idioma e atualiza todos os textos na scene atual
    /// </summary>
    public static void UpdateLanguage() {
        RefreshLanguague();
        foreach (var textLang in GameObject.FindObjectsOfType<TextLang>())
            textLang.UpdateText();
    }

}
