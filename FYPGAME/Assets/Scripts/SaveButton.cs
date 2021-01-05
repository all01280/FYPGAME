using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour
{
    SavePlayerPos playerPosData;
    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
    }

    public void SaveGame()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        playerPosData.PlayerPosSave();
    }
}
