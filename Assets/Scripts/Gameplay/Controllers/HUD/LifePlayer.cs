using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifePlayer : MonoBehaviour {

	void Start () {
        GetComponent<Text>().text = "Vidas x" + PlayerInfo.Lives;
	}
}
