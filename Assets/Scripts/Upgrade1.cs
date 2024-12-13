using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public int upgradeClickCost = 10;
    public int upgradeAutoClickCost = 20;
    public int upgradeGainCost = 30;
    //private int _upgradeDiversityCost = 40;

    public float autoClickPerSecond = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeClick()
    {
        if(Manager.instance.score >= upgradeClickCost)
        {
            Manager.instance.score -= upgradeClickCost;
            Manager.instance.powerClick = Manager.instance.powerClick * 1.5f;
            upgradeClickCost = (int)(upgradeClickCost * 1.5f);
            Debug.Log(upgradeClickCost);
        }
    }

    public void UpgradeAutoClick()
    {
        if (Manager.instance.score >= upgradeAutoClickCost)
        {
            if(Manager.instance.autoClickLevel < 1)
            {
                autoClickPerSecond = 5;
                Manager.instance.score -= upgradeAutoClickCost;
                Manager.instance.autoClickLevel = 1;
                StartCoroutine(CoroutineAutoClick());
            }
            else
            {
                Manager.instance.score -= upgradeAutoClickCost;
                autoClickPerSecond = autoClickPerSecond * 0.8f;
                Manager.instance.autoClickLevel++;
                Debug.Log(autoClickPerSecond + "autoclick");
                Debug.Log(upgradeAutoClickCost + "autoclick");
            }
        }
    }

    public IEnumerator CoroutineAutoClick()
    {
        while(Manager.instance.autoClickLevel > 0)
        {
            Manager.instance.objectReader.FabricObject();
            yield return new WaitForSecondsRealtime(autoClickPerSecond);
        }
    }

    public void UpgradeGain()
    {
        if (Manager.instance.score >= upgradeGainCost)
        {
            Manager.instance.score -= upgradeGainCost;
            Manager.instance.objectReader.coinMultiplicator *= 1.5f;
            upgradeGainCost = (int)(Mathf.Pow(upgradeGainCost, 1.1f));
            
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,20), upgradeGainCost.ToString());
    }
}
