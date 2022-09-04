using UnityEngine;


public class Harvester : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(0, 8);
    }
}
