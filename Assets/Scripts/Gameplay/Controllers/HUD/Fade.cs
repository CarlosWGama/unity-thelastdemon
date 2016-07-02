using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour {

    private Image image;

	void Awake () {
        image = GetComponent<Image>();
	}
	
	public void FadeIn() {
        image.enabled = true;

        StartCoroutine(ExecFadeIn());

        TimeManager.Paused = false;
    }

    IEnumerator ExecFadeIn() {
        while (image.color.a > 0) {
            var color = image.color;
            color.a -= 0.01f;
            image.color = color;
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }

    public void FadeOut() {
        gameObject.SetActive(true);
        TimeManager.Paused = true;
        StartCoroutine(ExecFadeOut());
    }

    IEnumerator ExecFadeOut() {
        while (image.color.a < 1) {
            var color = image.color;
            color.a += 0.01f;
            image.color = color;
            yield return new WaitForFixedUpdate();
        }
    }
}
