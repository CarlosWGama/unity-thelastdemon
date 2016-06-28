using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour {

    [SerializeField]
    private Text texto;

    private Rank rank;

    // Use this for initialization
    void Awake () {
        rank = SaveLoad.Load();

        foreach (ScorePerson score in rank.scores)
            texto.text += score.name + " - Level - " + score.level + " (" + score.Time + ") \n";
    }
	
	
}
