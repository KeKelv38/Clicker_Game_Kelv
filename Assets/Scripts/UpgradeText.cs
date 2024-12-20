using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeText : MonoBehaviour
{
    public TextMeshProUGUI upgradeClickText, upgradeAutoClickText, upgradeGainText, upgradeNewObjectLevelText;
    public TextMeshProUGUI upgradeClickCostText, upgradeAutoClickCostText, upgradeGainCostText, upgradeNewObjectCostText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upgradeClickText.text = Manager.instance.powerClick.ToString("000");
        upgradeAutoClickText.text = Manager.instance.upgrade1.autoClickPerSecond.ToString("0.000" + "*s");
        upgradeGainText.text = Manager.instance.objectReader.coinMultiplicator.ToString("000");
        upgradeNewObjectLevelText.text = Manager.instance.upgrade1.upgradeNewObjectLevel.ToString("000");

        upgradeClickCostText.text = Manager.instance.upgrade1.upgradeClickCost.ToString("000");
        upgradeAutoClickCostText.text = Manager.instance.upgrade1.upgradeAutoClickCost.ToString("000");
        upgradeGainCostText.text = Manager.instance.upgrade1.upgradeGainCost.ToString("000");
        upgradeNewObjectCostText.text = Manager.instance.upgrade1.upgradeNewObjectCost.ToString("000");
    }
}
