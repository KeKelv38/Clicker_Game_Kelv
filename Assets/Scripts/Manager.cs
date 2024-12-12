using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public float powerClick = 1f;
    public int autoClickLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("00");
    }
}
