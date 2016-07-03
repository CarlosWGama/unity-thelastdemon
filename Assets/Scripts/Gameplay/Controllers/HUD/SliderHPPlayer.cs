
public class SliderHPPlayer : SliderHP {

	void Start () {
        SetTotalHP(10);
        currentHP = PlayerInfo.HP;

    }

    public override void Hit() {
        base.Hit();
        PlayerInfo.HP = currentHP;
        if (PlayerInfo.HP <= 0)
            PlayerInfo.UseLife();
    }

}
