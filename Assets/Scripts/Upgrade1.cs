using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public Manager manager;
    public ObjectReader objectReader;

    private int upgradeClickCost = 50;
    private int upgradeAutoClickCost = 10;
    private int upgradeGainCost = 700;
    private int upgradeDiversityCost = 300;


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
        if(manager.score >= 50)
        {
            manager.score -= 50;
            manager.powerClick = manager.powerClick * 1.5f;
        }
    }

    public void UpagradeAutoClick()
    {
        if (manager.score >= upgradeAutoClickCost)
        {
            if(manager.autoClickLevel < 1)
            {
                manager.score -= upgradeAutoClickCost;
                manager.autoClickLevel = 1;
                StartCoroutine(CoroutineAutoClick());
            }
            else
            {
                manager.score -= upgradeAutoClickCost;
                manager.powerClick = manager.powerClick * 2;
            }
        }
    }

    public IEnumerator CoroutineAutoClick()
    {
        while(manager.autoClickLevel > 0)
        {
            objectReader.FabricObject();
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
