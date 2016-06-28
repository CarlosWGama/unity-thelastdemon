using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifePlayer : MonoBehaviour {

	void Awake () {
        GetComponent<Text>().text = "Vidas x" + PlayerInfo.Lives;
	}
}
