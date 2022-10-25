using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] players;

    // Start is called before the first frame update
    void Start()
    {
        int shipType = PlayerPrefs.GetInt(ShipSelectorController.SHIP_TYPE);
        Debug.Log("got ship type: " + shipType);
        Instantiate(players[shipType], transform.position, Quaternion.identity);

        //disable UI for the end of the game
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag(ConstantsHelper.TAG_GAME_OVER_UI))
        {
            obj.SetActive(false);
        }

        Destroy(gameObject);
    }
}
