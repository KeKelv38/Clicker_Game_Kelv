using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameSave()
    {
        PlayerPrefs.SetInt("Score", Manager.instance.score);
    }

    public void Load()
    {
        PlayerPrefs.GetInt("Score", Manager.instance.score);
    }
}
