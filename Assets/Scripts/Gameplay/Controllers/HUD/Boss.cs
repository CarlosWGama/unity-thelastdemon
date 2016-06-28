using UnityEngine;
using System.Collections;

public class Boss : SliderHP {

    private LevelController lvlct;

    void Start() {
        lvlct = FindObjectOfType<LevelController>();
        face.sprite = lvlct.BossSprite;
        SetTotalHP(FindObjectOfType<LevelController>().BossHP);
    }

    protected override void Update() {
        if (currentHP > lvlct.Simbolos)
            Hit();
        currentHP = lvlct.Simbolos;
        base.Update();
    }

}
