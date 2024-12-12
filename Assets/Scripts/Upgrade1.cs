using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public Manager manager;
    public ObjectReader objectReader;

    private int _upgradeClickCost = 10;
    private int _upgradeAutoClickCost = 20;
    private int _upgradeGainCost = 30;
    private int _upgradeDiversityCost = 40;

    private float _autoClickSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindFirstObjectByType<Manager>();
        objectReader = FindFirstObjectByType<ObjectReader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeClick()
    {
        if(manager.score >= _upgradeClickCost)
        {
            manager.score -= _upgradeClickCost;
            manager.powerClick = manager.powerClick * 1.5f;
        }
    }

    public void UpgradeAutoClick()
    {
        if (manager.score >= _upgradeAutoClickCost)
        {
            if(manager.autoClickLevel < 1)
            {
                manager.score -= _upgradeAutoClickCost;
                manager.autoClickLevel = 1;
                StartCoroutine(CoroutineAutoClick());
            }
            else
            {
                manager.score -= _upgradeAutoClickCost;
                _autoClickSpeed = _autoClickSpeed * 0.5f;
                manager.autoClickLevel++;
                Debug.Log(manager.autoClickLevel);
            }
        }
    }

    public IEnumerator CoroutineAutoClick()
    {
        while(manager.autoClickLevel > 0)
        {
            objectReader.FabricObject();
            yield return new WaitForSecondsRealtime(_autoClickSpeed);
        }
    }

    public void UpgradeGain()
    {
        if (manager.score >= _upgradeGainCost)
        {
            manager.score -= _upgradeGainCost;
            objectReader.coinMultiplicator *= 1.5f;
            _upgradeGainCost = (int)(Mathf.Pow(_upgradeGainCost, 1.1f));
            
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,20), _upgradeGainCost.ToString());
    }
}
