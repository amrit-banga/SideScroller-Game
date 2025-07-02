using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float levelBottomY; // Y-position of the bottom of the level
    public float levelTopY; // Y-position of the top of the level
    private Slider slider;

    void Start()
    {
        // Get the Slider component
        slider = GetComponent<Slider>();
        // Ensure the slider's range matches the level's range
        slider.minValue = 0f;
        slider.maxValue = 1f; // Normalized between 0 and 1
    }

    void Update()
    {
        // Calculate the player's progress
        float progress = Mathf.InverseLerp(levelBottomY, levelTopY, player.position.y);
        slider.value = progress;
    }
}
