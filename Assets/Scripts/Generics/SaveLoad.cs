using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Classe responsável por salvar os dados do jogo no pc do jogador
/// </summary>
public class SaveLoad {

   private static string filePath = Application.persistentDataPath;

    /// <summary> Método responsável por salvar o progresso no PC </summary>
	public static void Save(int slot = 1) {
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath + "/slot_" + slot + ".dat");
        bf.Serialize(file, GameplayInfo.Checkpoint);
        file.Close();


    }

    /// <summary> Método responsável por carregar o progresso no PC </summary>
    public static void Load(int slot = 1) {

        if (HasSave(slot)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath + "/slot_" + slot + ".dat", FileMode.Open);
            GameplayInfo.Checkpoint = (GameplayInfo.CheckPoint)bf.Deserialize(file);
            file.Close();
        }
    }

    /// <summary> Método responsável por verificar se há algo salvo </summary>
    public static bool HasSave(int slot) {
        return File.Exists(filePath + "/slot_" + slot + ".dat");
    }
}
