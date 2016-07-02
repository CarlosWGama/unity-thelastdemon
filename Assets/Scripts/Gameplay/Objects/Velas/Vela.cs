using UnityEngine;
using System.Collections;

/// <summary>
/// Vela padrão a ser encaixada no simbolo
/// </summary>
public class Vela : TileMove, IVela {

    /// <summary> Verifica se pode se mover</summary>
    private bool testMove = false;    

    void Update() {
        if (testMove) {
            testMove = false;
            
            if (CanMove())
                Move();
            
        } else if (isMoving) 
            Moving();
    }

    /// <summary>
    /// Empurra a vela
    /// </summary>
    /// <param name="direction">Direção a qual a vela é empurrada</param>
    public void Push(Tile.Direction direction) {
        this.direction = direction;
        testMove = true;
    }
}
