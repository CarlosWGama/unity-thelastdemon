using UnityEngine;
using System.Collections;

/// <summary> Classe responsável por mover os objetos no mapa </summary>
public abstract class TileMove : MonoBehaviour {

    [SerializeField]
    /// <summary> Direção atual do Objeto </summary>
    protected Tile.Direction direction = Tile.Direction.Down;

    /// <summary> Objeto que checa se o movimento pode ser realizado </summary>
    protected CheckController directionCollider;

    /// <summary> Verifica se está executando um movimento </summary>
    protected bool isMoving = false;

    /// <summary> Destino </summary>
    protected Vector3 target;

    [SerializeField]
    /// <summary> Velocidade com qual o objeto se move </summary>
    protected float speed = 1f;

    protected virtual void Awake() {
        directionCollider = GetComponentInChildren<CheckController>();
    }

    /// <summary>
    /// Verifica se o objeto pode se mover na direção que está
    /// </summary>
    /// <returns></returns>
    protected bool CanMove() { 
        return (directionCollider.CanMove(direction));
    }

    public bool CanMove(Tile.Direction direction) {
        this.direction = direction;
        return CanMove();
    }

    /// <summary>
    /// Verifica se pode empurrar
    /// </summary>
    /// <returns></returns>
    protected bool CanPushing() {
        if (directionCollider.CanPushing(direction)) {
            var vela = GetVela();
            return vela.CanMove(direction);    
        }
        return false;
    }
    
    /// <summary>
    /// Recupera a vela que estiver escostado na direção
    /// </summary>
    /// <returns></returns>
    protected IVela GetVela() {
        return directionCollider.GetVela(direction);
    }

    /// <summary>
    /// Define o local para onde será movido
    /// </summary>
    protected void Move() {
        isMoving = true;
        Tile.CanMove = false;
        switch (direction) {
            case Tile.Direction.Up: target = transform.position + Vector3.up; break;
            case Tile.Direction.Down: target = transform.position - Vector3.up; break;
            case Tile.Direction.Left: target = transform.position - Vector3.right; break;
            case Tile.Direction.Right: target = transform.position + Vector3.right; break;
        }
    }

    /// <summary>
    /// Movimenta o objeto
    /// </summary>
    protected void Moving() {
        if (transform.position == target) {
            isMoving = false;
            Tile.CanMove = true;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
