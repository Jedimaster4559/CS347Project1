using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject creditsPanel;
    public Text sceneNameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DisplayCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void ToggleScene()
    {
        if (SceneManager.GetActiveScene().name.Equals("Original"))
        {
            SceneManager.LoadScene("Fixed");
            sceneNameText.text = "Fixed Version";
        } else
        {
            SceneManager.LoadScene("Original");
            sceneNameText.text = "Original Version";
        }
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
}
