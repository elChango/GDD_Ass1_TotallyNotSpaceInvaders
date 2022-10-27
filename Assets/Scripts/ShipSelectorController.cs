using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipSelectorController : MonoBehaviour
{
    public static string SHIP_TYPE = "ship_type";

    public void SelectShip0()
    {
        PlayerPrefs.SetInt(SHIP_TYPE, 0);
        SceneManager.LoadScene(ConstantsHelper.SCENE_LEVEL_ONE);
    }

    public void SelectShip1()
    {
        PlayerPrefs.SetInt(SHIP_TYPE, 1);
        SceneManager.LoadScene(ConstantsHelper.SCENE_LEVEL_ONE);
    }
}
