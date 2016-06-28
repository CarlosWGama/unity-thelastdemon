using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SaveScore : MonoBehaviour {

    [Header("Salvar Score")]
    [SerializeField]
    private Text time;

    [SerializeField]
    private Text level;

    [SerializeField]
    private InputField nome;

    private Rank rank;

	void Awake () {
        time.text = PlayerInfo.TimePlayingFormatted;
        level.text = PlayerInfo.CurrentLevel.ToString();
        rank = SaveLoad.Load();
    }
	
    public void Save() {
        var score = new ScorePerson(nome.text, PlayerInfo.TimePlaying, PlayerInfo.CurrentLevel);
        rank.AddScore(score);
        SaveLoad.Save(rank);
        SceneManager.LoadScene("Rank");
    }
}
