using UnityEngine;
using System.Collections;

public class CheckCollider : MonoBehaviour {

    private Tile.Direction direction;
    public Tile.Direction Direction {
        set {
            switch (value) {
                case Tile.Direction.Right: transform.localPosition = Vector3.right; break;
                case Tile.Direction.Left: transform.localPosition = -Vector3.right; break;
                case Tile.Direction.Up: transform.localPosition = Vector3.up; break;
                case Tile.Direction.Down: transform.localPosition = -Vector3.up; break;
            }
            direction = value;
        }
        get { return direction;  }
    }

    /// <summary> Verifica se o objeto pode se mover </summary>
    private bool canMove = true;
    public bool CanMove {
        get { return canMove; }
    }

    /// <summary> Verifica se há algo para empurra </summary>
    private bool isPushing;
    public bool IsPushing {
        get { return isPushing; }
    }

    private IVela vela;
    public IVela Vela { get { return vela; } }

    private bool updateTrigger;
    private bool updateBox;
    void FixedUpdate() {
        if (updateTrigger) {
            updateTrigger = false;
            updateBox = false;
        }
    }

    void OnTriggerEnter2D(Collider2D colisor) {
        updateTrigger = true;
        canMove = false;
        if (colisor.gameObject.tag.Equals("Vela")) {
            vela = colisor.gameObject.GetComponent<IVela>();
            isPushing = true;
            updateBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D colisor) {
        if (!updateTrigger) 
            canMove = true;
        if (!updateBox)
            isPushing = false;
    }

    
}
