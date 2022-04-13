using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    private List<GameObject>[][] _grid; // Should be a list of Cells?
    public static Grid instance;
    private void Start() {
        // Singleton
        instance = this;
    }

    public Vector2 worldToGridPos(Vector3 worldPosition) {
        return new Vector2();
    }
    public Vector3 gridToWorldPos(Vector2 gridPosition) {
        return new Vector3();
    }
    public bool isWalkable(Vector2 gridPosition) {
        return true;
    }
    public bool isWalkable(Vector3 WorldPosition) {
        return true;
    }
    public bool isBombable(Vector2 gridPosition) {
        // Checks if there is a bomb.
        return true;
    }
    public bool isBombable(Vector3 WorldPosition) {
        // Checks if there is a bomb.
        return true;
    }

    public List<GameObject> findHitsFrom(Vector3 worldPosition, int range) {
        return new List<GameObject>();
    }
    
    public void Move(Bomberman character, Vector2 MovementDirection) {
        // We should probably index characters in a dictionary or object, containing the character's and objects current positions.
        Vector2 position = dict[character]; //lookup  or character.playerNumber
        // Movement direction is the captured motion of the controller may be dirty(diagonal) so maybe only capture one axis? 
        // update the grid.
        Vector2 targetPosition = position + MovementDirection;
        if (!isWalkable(targetPosition)) return;
        
        // Move!
        _grid[position.x][position.y] = null; // Actually cell.empty()
        _grid[targetPosition.x][targetPosition.y] = character; // cell.setchar(character)
        dict[character] = targetPosition;

        if (targetCell.containsCollectible()){
            character.pickup(targetCell.getCollectible());
            targetCell.destroyCollectible();
        }
        
        character.Movement(gridToWorldPos(targetPosition));
    }
}
