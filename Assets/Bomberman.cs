using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomberman : MonoBehaviour
{
    public GameObject bombPrefab;
    public int playerNumber;
    private float speed = 1f;
    private int bombRange = 1;
    private int maxBombs = 1;
    public int spawnedBombs;

    public bool isMoving = false;
    
    private void Start() {
        spawnedBombs = 0;
    }
    public void PlaceBomb(){
        if (spawnedBombs >= maxBombs) return;
        if (!(Grid.instance.isBombable(transform.position))) return;

        GameObject bombInstance = Instantiate(bombPrefab, transform.position, transform.rotation, transform);
        Bomb spawnedBomb = bombInstance.GetComponent<Bomb>();
        spawnedBomb.setTimer(this, bombRange);
        spawnedBombs += 1;
    }

    private void OnDestroy() {
        // Some animations
    }

    public void Movement(Vector3 targetPosition) {
        isMoving = true;
        // Movement should be handled by the grid.
        // This probably should just Lerp the animation sprite.
        
        // Maybe also set the world position for this object.
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed); // Doing it wrong. Need to set target position externally and Lerp on update().
        // Once invocations are done.
        isMoving = false;

    }
    public void Pickup(Collectible collectible){

        // Maybe add a Stats class and edit the class behavior when doing += operations. So do... characterStats += collectibleStats.
        if (collectible.type == CollectibleTypes.maxBombsUpgrade){
            maxBombs += 1;
        }
        if (collectible.type == CollectibleTypes.bombRangeUpgrade){
            bombRange += 1;
        }
        if (collectible.type == CollectibleTypes.speedUpgrade){
            speed /= 2; // Twice as fast!
        }
    }
}
