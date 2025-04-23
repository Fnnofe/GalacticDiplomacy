using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
            // Load the actual game scene as a background
            SceneManager.LoadSceneAsync("Demo Level Ahmed latest", LoadSceneMode.Additive);
        
    }
    
}
