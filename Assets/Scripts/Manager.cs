using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public ObjectReader objectReader;
    public Upgrade1 upgrade1;
    public JuicyEffect juicyEffect;
    public ObjectsAppearAnimation objectsAppearAnimation;
    public UpgradeColorAnimation upgradeColorAnimation;



    public int score = 0;
    public TextMeshProUGUI scoreText;

    public float powerClick = 1f;
    public int autoClickLevel = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        objectReader = FindFirstObjectByType<ObjectReader>();
        upgrade1 = FindFirstObjectByType<Upgrade1>();
        juicyEffect = FindFirstObjectByType<JuicyEffect>();
        objectsAppearAnimation = FindFirstObjectByType<ObjectsAppearAnimation>();

        scoreText.text = score.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("00");
    }
}
