using UnityEngine;
using System.Collections;

/// <summary>Classe responsável por pausar animações</summary>
public class AnimationPauseManager : MonoBehaviour {

    private Animator animator;

    void Awake () {
        animator = GetComponent<Animator>();
	}

    /// <summary>Caso o tempo esteja pausado, a animação não se move</summary>
    void Update () {
        if (TimeManager.Paused && !TimeManager.SemiPaused)
            animator.speed = 0f;
        else
            animator.speed = 1f;
    }
}
