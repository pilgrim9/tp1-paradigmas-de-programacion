using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int bombRange;
    private Bomberman bombOwner;
    private float timer = 5;

    public void setTimer(Bomberman character, int characterRange){
        bombRange = characterRange;
        Invoke("Explode", timer);
    }
    private void Explode() {
        
        //Probably some simple pathfinding done at the grid level in 4 directions. 
        List<GameObject> hits = Grid.instance.findHitsFrom(transform.position, bombRange);

        // Maybe this for should be Grid.instance.destroyIterable(hits);
        foreach (GameObject hit in hits)
        {
            Grid.instance.remove(hit);
            Destroy(hit);
        }
        Destroy(gameObject); // destroy the bomb.
    }

    private void OnDestroy() {
        bombOwner.spawnedBombs -= 1; // Probably breaks if onwer was destroyed by explotion.
    }
}  
