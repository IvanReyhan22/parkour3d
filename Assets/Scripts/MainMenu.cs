using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelOne;
    public string options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelOne);
    }
    public void ControlGame()
    {
        SceneManager.LoadScene(options);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quittingg....");
    }
}
