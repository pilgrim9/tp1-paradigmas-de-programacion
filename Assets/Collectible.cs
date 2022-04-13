using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleTypes type; // set on the prefab :)
    private void OnDestroy() {
        // Some sound effects
    }
}

