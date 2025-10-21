using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string sceneToPoen;
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneToPoen);
        

    }

}


