using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStory : MonoBehaviour
{
    void OnEnable() 
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
