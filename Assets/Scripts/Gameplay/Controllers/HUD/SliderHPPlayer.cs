using UnityEngine.SceneManagement;
using System.Collections;

public class SliderHPPlayer : SliderHP {

	void Start () {
        SetTotalHP(5);
        currentHP = PlayerInfo.HP;

    }

    public override void Hit() {
        base.Hit();
        PlayerInfo.HP = currentHP;
        if (PlayerInfo.HP <= 0)
            PlayerInfo.UseLife();
            

    }

}
