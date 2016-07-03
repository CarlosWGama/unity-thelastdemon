﻿using UnityEngine;
using UnityEngine.UI;

public class SliderHPPlayer : SliderHP {

    private Text texto;

	void Start () {
        SetTotalHP(10);
        currentHP = PlayerInfo.HP;
        texto = GetComponentInChildren<Text>();
    }

    protected override void Update() {
        base.Update();
        texto.text = "HP " + slider.value + "/" + slider.maxValue;
    }

    public override void Hit() {
        base.Hit();
        PlayerInfo.HP = currentHP;
        if (PlayerInfo.HP <= 0)
            PlayerInfo.UseLife();
    }

}
