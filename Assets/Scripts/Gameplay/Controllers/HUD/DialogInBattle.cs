using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInBattle : MonoBehaviour {


    /// <summary> Panel do Player </summary>
    private GameObject playerBalloon;
    /// <summary> Text do Player </summary>
    private Text playerText;
    /// <summary> Panel do Boss </summary>
    private GameObject bossBalloon;
    /// <summary> Text do Boss </summary>
    private Text bossText;

    void Awake() {
        playerBalloon = transform.GetChild(0).gameObject;
        playerText = playerBalloon.GetComponentInChildren<Text>();
        bossBalloon = transform.GetChild(1).gameObject;
        bossText = bossBalloon.GetComponentInChildren<Text>();
    }

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
