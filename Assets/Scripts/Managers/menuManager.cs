using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

    public int prototypeScene;

public void loadPrototypeScene ()
    {
        SceneManager.LoadScene(prototypeScene);
    }

    public void closeGame ()
    {
        Application.Quit();
    }
}
