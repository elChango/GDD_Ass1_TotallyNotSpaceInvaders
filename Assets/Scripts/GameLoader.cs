using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(ConstantsHelper.SCENE_SHIP_SELECTION);
    }
}
