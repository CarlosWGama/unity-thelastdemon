using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Classe responsável por salvar os dados do jogo no pc do jogador
/// </summary>
public class SaveLoad {

    /// <summary> Método responsável por salvar o progresso no PC </summary>
	public static void Save(Rank rank) {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/scoreData.dat");
        bf.Serialize(file, rank);
        file.Close();


    }

    /// <summary> Método responsável por carregar o progresso no PC </summary>
    public static Rank Load(string fileName = "/scoreData.dat") {
        Rank rank = new Rank();
        if (HasSave()) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            rank = (Rank)bf.Deserialize(file);
            file.Close();
        }
        return rank;
    }

    /// <summary> Método responsável por verificar se há algo salvo </summary>
    public static bool HasSave() {
        return File.Exists(Application.persistentDataPath + "/scoreData.dat");
    }
}
