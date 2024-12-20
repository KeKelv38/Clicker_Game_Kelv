using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public int upgradeClickCost = 10;
    public int upgradeAutoClickCost = 20;
    public int upgradeGainCost = 30;
    public int upgradeNewObjectCost = 10;
    //private int _upgradeDiversityCost = 40;

    public float autoClickPerSecond = 0;

    public int upgradeNewObjectLevel = 0;

    [SerializeField]
    private ObjectReader _or;
    private ObjectToFabric _currentObject;
    private int _counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        _currentObject = _or.objectList[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RiseCounter()
    {
        if (_counter + 1 >= _or.objectList.Count)
        {
            _counter = 0;
        }
        else
        {
            _counter += 1;
        }

        _currentObject = _or.objectList[ _counter ];
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
                upgradeAutoClickCost = (int)(upgradeAutoClickCost * 1.5f);
                StartCoroutine(CoroutineAutoClick());
            }
            else
            {
                Manager.instance.score -= upgradeAutoClickCost;
                autoClickPerSecond = autoClickPerSecond * 0.8f;
                upgradeAutoClickCost = (int)(upgradeAutoClickCost * 1.5f);
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

    public void UpgradeNewObjectTest()
    {
        if (Manager.instance.score >= upgradeNewObjectCost)
        {
            upgradeNewObjectLevel++;
            Manager.instance.score -= upgradeAutoClickCost;
            upgradeNewObjectCost = (int)(Mathf.Pow(upgradeNewObjectCost, 1.1f));
            //Manager.instance.objectReader.objectList.Add(_shovel, 2);
            Manager.instance.objectReader.objectList.SetWeightOfObject(_currentObject, 5);
            RiseCounter();
            Debug.Log(_counter);

        }
    }


    private void OnGUI()
    {
        //GUI.Label(new Rect(10,10,100,20), upgradeGainCost.ToString());
    }
}
