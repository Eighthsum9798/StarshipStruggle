using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    // Array of buttons to be assigned in the Inspector
    public Button[] buttonsArray;
    // Currently selected button
    private Button selectedButton;

    

    // Start is called before the first frame update
    void Start()
    {
        // Add listener to each button in the array
        foreach (Button button in buttonsArray)
        {
            button.onClick.AddListener(() => buttonClick(button)); 
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "4" key is pressed and a button is selected
        if (Input.GetKeyDown(KeyCode.Keypad4) && selectedButton != null)
        {
            // Invoke the onClick event of the selected button
            selectedButton.onClick.Invoke();
        }
    }

    // Method to handle button clicks
    void buttonClick(Button clickedButton)
    {
        // Update the selected button
        selectedButton = clickedButton;
        // Log the name of the clicked button
        Debug.Log("clicked" + clickedButton.name);
    }

}
