using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverHandler : MonoBehaviour
{
    public void LoadMenuScreen()
    {
        SceneManager.LoadScene(ConstantsHelper.SCENE_MENU_SCREEN);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(ConstantsHelper.SCENE_LEVEL_ONE);
    }

}
