using UnityEngine;
using System.Collections;

public class Player : TileMove {

    private SliderHPPlayer sliderHP;
    private SliderSt sliderSt;

    private Tile.Direction Direction {
        set { 
            if (direction != value)
                updateDirection = true;
            direction = value;
        }
    }
    /// <summary>
    /// Atualiza a animação de movimento e evitar checagem errada
    /// </summary>
    private bool updateDirection = false;

    /// <summary> Controla as animação </summary>
    private Animator animator;

	protected override void Awake () {
        base.Awake();
        animator = GetComponent<Animator>();
	}

    void Start() {
        sliderHP = FindObjectOfType<SliderHPPlayer>();
        sliderSt = FindObjectOfType<SliderSt>();
    }
	

	void LateUpdate () {
        if (!TimeManager.Paused) { 
            if (!isMoving) {
                if ((Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && Tile.CanMove) 
                    Turn();   
            } else {
                Moving();
            }
        }

        //Animations
        animator.SetInteger("Direction", (int)direction);
        animator.SetBool("Moving", isMoving);
        if (updateDirection) { 
            animator.SetTrigger("UpdateDirection");
            updateDirection = false;    //Evita bug de colisão
        }

    }

    void Turn() {
        //Turn
        if (Input.GetAxisRaw("Horizontal") > 0)
            directionCollider.Direction = Direction = Tile.Direction.Right; //Direita
        else if (Input.GetAxisRaw("Horizontal") < 0)
            directionCollider.Direction = Direction = Tile.Direction.Left; //Esquerda
        else if (Input.GetAxisRaw("Vertical") > 0)
            directionCollider.Direction = Direction = Tile.Direction.Up; //Cima
        else if (Input.GetAxisRaw("Vertical") < 0)
            directionCollider.Direction = Direction = Tile.Direction.Down; //Baixo

        StartCoroutine(Action());
    }

    IEnumerator Action() {
        yield return new WaitForFixedUpdate();
        //Se atualizou a direção, checa no próximo frame
        if (directionCollider.CanMove) {

            if (sliderSt.HasStamina) //Usa Stamina
                sliderSt.Use(); 
            else                    //Causa dano
                sliderHP.Hit();
            Move();
        } else if (directionCollider.IsPushing)
            Push();
    }

    void Push() {
        animator.SetTrigger("Pushing");
        directionCollider.Vela.Push(direction);
    }
}
