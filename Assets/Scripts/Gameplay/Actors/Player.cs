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


#if UNITY_EDITOR
    private int passos;
#endif

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
                    Action();   
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

    void Action() {
        //Turn
        if (Input.GetAxisRaw("Horizontal") > 0)
            Direction = Tile.Direction.Right; //Direita
        else if (Input.GetAxisRaw("Horizontal") < 0)
            Direction = Tile.Direction.Left; //Esquerda
        else if (Input.GetAxisRaw("Vertical") > 0)
            Direction = Tile.Direction.Up; //Cima
        else if (Input.GetAxisRaw("Vertical") < 0)
            Direction = Tile.Direction.Down; //Baixo

        if (CanMove() || CanPushing()) {
            if (sliderSt.HasStamina) //Usa Stamina
                sliderSt.Use();
            else                    //Causa dano
                sliderHP.Hit();
            Move();
#if UNITY_EDITOR
            passos++;
            Debug.Log(passos);
#endif
            if (CanPushing())           
                Push();
        }
    }
    /*
    IEnumerator Action() {
        yield return new WaitForFixedUpdate();
        //Se atualizou a direção, checa no próximo frame
        if (directionCollider.CanMove) {

            if (sliderSt.HasStamina) //Usa Stamina
                sliderSt.Use(); 
            else                    //Causa dano
                sliderHP.Hit();
            Move();
#if UNITY_EDITOR
            passos++;
            Debug.Log(passos);
#endif
        }
        else if (directionCollider.IsPushing)
            Push();
    }
    */
    void Push() {
        animator.SetTrigger("Pushing");
        GetVela().Push(direction);
    }
}
