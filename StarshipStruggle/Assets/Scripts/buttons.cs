using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    public Button[] buttonsArray;
    
    private Button selectedButton;

    

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button button in buttonsArray)
        {
            button.onClick.AddListener(() => buttonClick(button)); 
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4) && selectedButton != null)
        {
            selectedButton.onClick.Invoke();
        }
    }

    void buttonClick(Button clickedButton)
    {
        selectedButton = clickedButton;
        Debug.Log("clicked" + clickedButton.name);
    }

}
