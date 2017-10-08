using UnityEngine;
using UnityEngine.UI;

public class SliderHPPlayer : SliderHP {

  
    public AudioClip morteSE;

	void Start () {
        SetTotalHP(10);
        currentHP = PlayerInfo.HP;
    }

    protected override void Update() {
        base.Update();
    }

    public override void Hit() {
        base.Hit();
        PlayerInfo.HP = currentHP;
        if (PlayerInfo.HP <= 0) {
            SoundManager.instance.PlaySE(morteSE);
            PlayerInfo.UseLife();
        }
            
    }

}
