using UnityEngine;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;

public class CutsceneEditor {

    [MenuItem("Assets/Create/Dialogo")]
    static void CreateDialogo() {
        var asset = ScriptableObject.CreateInstance<Dialogo>();

        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                asset.GetInstanceID(),
                ScriptableObject.CreateInstance<EndNameCutScene>(),
                "Dialogo.asset",
                AssetPreview.GetMiniThumbnail(asset),
                null);
    }

    [MenuItem("Assets/Create/Cutscene")]
    static void CreateCutscene() {
        var asset = ScriptableObject.CreateInstance<Cutscene>();

        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                asset.GetInstanceID(),
                ScriptableObject.CreateInstance<EndNameCutScene>(),
                "Dialogo.asset",
                AssetPreview.GetMiniThumbnail(asset),
                null);
    }
}

internal class EndNameCutScene : EndNameEditAction { 
    #region Implementa classe Abstrata
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        AssetDatabase.CreateAsset(EditorUtility.InstanceIDToObject(instanceId), AssetDatabase.GenerateUniqueAssetPath(pathName));
    }
    #endregion
}