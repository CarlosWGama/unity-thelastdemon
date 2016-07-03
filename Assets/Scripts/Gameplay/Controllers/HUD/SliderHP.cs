using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class SliderHP : MonoBehaviour {

    [SerializeField]
    private AudioClip hitSound;
    private int totalHP;
    protected int currentHP;
    protected Slider slider;
    [SerializeField]
    protected Image face;

    void Awake() {
        slider = GetComponent<Slider>();
    }

	protected void SetTotalHP (int hp) {
        currentHP = totalHP = hp;
        slider.value = slider.maxValue = currentHP;
	}
	
	protected virtual void Update () {
        slider.value = currentHP;
	}

    public virtual void Hit() {
        currentHP--;
        SoundManager.instance.PlaySE(hitSound);
        StartCoroutine(NormalizeColor());
    }

    IEnumerator NormalizeColor() {
        face.color = Color.red;

        while(face.color.b < 1) {
            var color = face.color;
            color.b = color.g = color.g + 0.05f;
            face.color = color;
            yield return new WaitForFixedUpdate();
        }

    }
}
