using UnityEngine;
using System.Collections;

public class CheckController : MonoBehaviour {

    private CheckCollider colliderUp;
    private CheckCollider colliderDown;
    private CheckCollider colliderRight;
    private CheckCollider colliderLeft;

    void Awake() {
        colliderUp = transform.GetChild(0).GetComponent<CheckCollider>();
        colliderRight = transform.GetChild(1).GetComponent<CheckCollider>();
        colliderDown = transform.GetChild(2).GetComponent<CheckCollider>();
        colliderLeft = transform.GetChild(3).GetComponent<CheckCollider>();
    }

    public bool CanMove(Tile.Direction direction) {
        switch(direction) {
            case Tile.Direction.Up:     return colliderUp.CanMove; 
            case Tile.Direction.Right:  return colliderRight.CanMove; 
            case Tile.Direction.Down:   return colliderDown.CanMove; 
            case Tile.Direction.Left:   return colliderLeft.CanMove; 
        }
        return true;
    }

    public bool CanPushing(Tile.Direction direction) {
        switch (direction) {
            case Tile.Direction.Up: return colliderUp.CanPushing;
            case Tile.Direction.Right: return colliderRight.CanPushing;
            case Tile.Direction.Down: return colliderDown.CanPushing;
            case Tile.Direction.Left: return colliderLeft.CanPushing;
        }
        return true;
    }

    public IVela GetVela(Tile.Direction direction) {
        switch (direction) {
            case Tile.Direction.Up: return colliderUp.Vela;
            case Tile.Direction.Right: return colliderRight.Vela;
            case Tile.Direction.Down: return colliderDown.Vela;
            case Tile.Direction.Left: return colliderLeft.Vela;
        }
        return null;
    }
}
