using UnityEngine;
using System.Collections;

public class CheckCollider : MonoBehaviour {

    /// <summary> Verifica se o objeto pode se mover </summary>
    [SerializeField]
    private bool canMove = true;
    public bool CanMove {
        get { return canMove; }
    }

    /// <summary> Verifica se há algo para empurra </summary>
    private bool canPushing;
    public bool CanPushing {
        get { return canPushing; }
    }

    private IVela vela;
    public IVela Vela { get { return vela; } }

    void OnTriggerEnter2D(Collider2D colisor) {
        canMove = false;
        if (colisor.gameObject.tag.Equals("Vela")) {
            vela = colisor.gameObject.GetComponent<IVela>();
            canPushing = true;
        }
    }

    void OnTriggerExit2D(Collider2D colisor) {
        canMove = true;
        canPushing = false;
    }  
}
