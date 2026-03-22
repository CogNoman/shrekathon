using UnityEngine;

public class FixDelayed : MonoBehaviour
{
    // Drag your Audio Source into this slot in the Inspector
    public AudioSource clickSource;

    // This is the function you will select in the Button's OnClick list
    public void PlayButtonSound()
    {
        // 0.5f is the delay in seconds. 
        // Feel free to change this to 0.2f if 0.5f feels too slow!
        clickSource.PlayDelayed(0.5f);
    }
}