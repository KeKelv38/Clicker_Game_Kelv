using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeText : MonoBehaviour
{
    public TextMeshProUGUI upgradeClickText, upgradeAutoClickText, upgradeGainText;
    public TextMeshProUGUI upgradeClickCostText, upgradeAutoClickCostText, upgradeGainCostText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upgradeClickText.text = Manager.instance.powerClick.ToString("00");
        upgradeAutoClickText.text = Manager.instance.upgrade1.autoClickPerSecond.ToString("00");
        upgradeGainText.text = Manager.instance.objectReader.coinMultiplicator.ToString("00");

        upgradeClickCostText.text = Manager.instance.upgrade1.upgradeClickCost.ToString("00");
        upgradeAutoClickCostText.text = Manager.instance.upgrade1.upgradeAutoClickCost.ToString("00");
        upgradeGainCostText.text = Manager.instance.upgrade1.upgradeGainCost.ToString("00");  
    }
}
