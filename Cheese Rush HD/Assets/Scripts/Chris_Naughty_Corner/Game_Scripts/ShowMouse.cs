using UnityEngine;
using UnityEngine.UI;

public class ShowMouse : MonoBehaviour
{
    public Button backButton;

    private void Start()
    {
        // Make sure the cursor is visible and unlocked when the UI starts
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Attach the click event to the button
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked()
    {
        // Load a scene or perform other actions

        // Unlock and show the mouse cursor when going back to the main game scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}