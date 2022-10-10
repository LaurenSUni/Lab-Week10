using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 

    void Start()
    {
        
    }

    public void LoadFirstLevel()
    {
        //load the WalkingScene while preserving the game object that this component is attached to
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("WalkingScene");
        //set OnSceneLoaded(...) as a C# delegate of SceneManager.sceneLoaded (hint: see SceneManager.sceneLoaded)
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if scene in parameters has the build index of the WalkingScene, find the GameObject with the tag "QuitButton" to ge the Button component
        //with the button component, add the QuitGame() method as a listener of the onClick property (hint: Button.onClick)
        
        if (scene.buildIndex == SceneManager.GetSceneByName("WalkingScene").buildIndex ){
            GameObject button = GameObject.FindWithTag("QuitButton");
            Button buttonComponent = button.GetComponent<Button>();
            buttonComponent.onClick.AddListener(QuitGame);
        }
    }

    void Update()
    {
        
    }
}
