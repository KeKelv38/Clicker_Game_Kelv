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
        Debug.Log("Le score save est" +  Manager.instance.score);

        PlayerPrefs.SetFloat("PowerClick", Manager.instance.powerClick);
        PlayerPrefs.SetInt("UpgradeClickCost", Manager.instance.upgrade1.upgradeClickCost);

        PlayerPrefs.SetFloat("AutoClickPerSecond", Manager.instance.upgrade1.autoClickPerSecond);
        PlayerPrefs.SetInt("UpgradeClickCost", Manager.instance.upgrade1.upgradeClickCost);

        PlayerPrefs.SetFloat("CoinMultiplicator", Manager.instance.objectReader.coinMultiplicator);
        PlayerPrefs.SetInt("UpgradeGainCost", Manager.instance.upgrade1.upgradeGainCost);

        PlayerPrefs.SetFloat("Weight3", Manager.instance.objectReader.objectList.GetWeightAtIndex(3));
        PlayerPrefs.SetFloat("Weight4", Manager.instance.objectReader.objectList.GetWeightAtIndex(4));
        PlayerPrefs.SetFloat("Weight5", Manager.instance.objectReader.objectList.GetWeightAtIndex(5));
        PlayerPrefs.SetInt("UpgradeNewObjectLevel", Manager.instance.upgrade1.upgradeNewObjectLevel);



    }

    public void Load()
    {
        Manager.instance.score = PlayerPrefs.GetInt("Score");
        Debug.Log("Le score laod est " + Manager.instance.score);

        Manager.instance.powerClick = PlayerPrefs.GetFloat("PowerClick");
        Manager.instance.upgrade1.upgradeClickCost = PlayerPrefs.GetInt("UpgradeClickCost");

        Manager.instance.upgrade1.autoClickPerSecond = PlayerPrefs.GetFloat("AutoClickPerSecond");
        Manager.instance.upgrade1.upgradeClickCost = PlayerPrefs.GetInt("UpgradeClickCost");

        Manager.instance.objectReader.coinMultiplicator = PlayerPrefs.GetFloat("CoinMultiplicator");
        Manager.instance.upgrade1.upgradeGainCost = PlayerPrefs.GetInt("UpgradeGainCost");

        PlayerPrefs.GetFloat("Weight3", Manager.instance.objectReader.objectList.GetWeightAtIndex(3));
        PlayerPrefs.GetFloat("Weight4", Manager.instance.objectReader.objectList.GetWeightAtIndex(4));
        PlayerPrefs.GetFloat("Weight5", Manager.instance.objectReader.objectList.GetWeightAtIndex(5));
        Manager.instance.upgrade1.upgradeNewObjectLevel = PlayerPrefs.GetInt("UpgradeNewObjectLevel");
    }
}
