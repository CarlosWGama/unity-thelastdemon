using UnityEngine;

public class Simbolo : MonoBehaviour, ISimbolo {

    private LevelController levelController;

    void Start() {
        levelController = FindObjectOfType<LevelController>();
    }

	void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Vela")) {
            levelController.EnterInSimbolo();
        }
    }

    void OnTriggerExit2D(Collider2D colisor) {
        if (colisor.gameObject.tag.Equals("Vela")) {
            levelController.LeaveSimbolo();
        }
    }
}
