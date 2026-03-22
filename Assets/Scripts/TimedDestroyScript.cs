using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    // Public variable to set the time delay in the Inspector
    public float destructionDelay = 5.0f;

    void Start()
    {
        // Destroys the GameObject (the one this script is attached to) 
        // after the specified delay in seconds.
        Destroy(gameObject, destructionDelay);
    }
}