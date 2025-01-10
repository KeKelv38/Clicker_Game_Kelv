using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public int upgradeClickCost = 50;
    public int upgradeAutoClickCost = 100;
    public int upgradeGainCost = 300;
    public int upgradeNewObjectCost = 500;
    //private int _upgradeDiversityCost = 40;

    public float autoClickPerSecond = 0;

    public int upgradeNewObjectLevel = 0;

    [SerializeField]
    private ObjectReader _or;
    private ObjectToFabric _currentObject;
    //private int _counter = 0;
    private int _countObjectOrder = 3;

    [SerializeField]
    private GameObject _panelMaxUpgrade;



    // Start is called before the first frame update
    void Start()
    {
        //_currentObject = _or.objectList[3];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //----------------------------compteur, pour les poids----------------------------
    //private void RiseCounter()
    //{
    //    if (_counter + 1 >= _or.objectList.Count)
    //    {
    //        _counter = 0;
    //    }
    //    else
    //    {
    //        _counter += 1;
    //    }
    //
    //    _currentObject = _or.objectList[ _counter ];
    //}




    //permet d'améliorer la puissance de clique
    public void UpgradeClick()
    {
        if(Manager.instance.score >= upgradeClickCost && Manager.instance.powerClick == 1)
        {
            Manager.instance.score -= upgradeClickCost;
            Manager.instance.powerClick = Manager.instance.powerClick * 2f;
            upgradeClickCost = (int)(upgradeClickCost * 1.5f);
            Debug.Log(upgradeClickCost);
        }
        else if (Manager.instance.score >= upgradeClickCost)
        {
            Manager.instance.score -= upgradeClickCost;
            Manager.instance.powerClick = Manager.instance.powerClick * 1.5f;
            upgradeClickCost = (int)(upgradeClickCost * 1.5f);
            Debug.Log(upgradeClickCost);
        }
    }

    //permet de cliquer automatiquement, si amélioré, alors réduit le temps entre chaque auto-clique
    public void UpgradeAutoClick()
    {
        if (Manager.instance.score >= upgradeAutoClickCost)
        {
            if(Manager.instance.autoClickLevel < 1)
            {
                autoClickPerSecond = 5;
                Manager.instance.score -= upgradeAutoClickCost;
                Manager.instance.autoClickLevel = 1;
                upgradeAutoClickCost = (int)(upgradeAutoClickCost * 1.3f);
                StartCoroutine(CoroutineAutoClick());
            }
            else
            {
                Manager.instance.score -= upgradeAutoClickCost;
                autoClickPerSecond = autoClickPerSecond * 0.7f;
                upgradeAutoClickCost = (int)(upgradeAutoClickCost * 1.3f);
                Manager.instance.autoClickLevel++;
                Debug.Log(autoClickPerSecond + "autoclick");
                Debug.Log(upgradeAutoClickCost + "autoclick");
            }
        }
    }
    
    //couroutine pour l'auto-clique
    public IEnumerator CoroutineAutoClick()
    {
        while(Manager.instance.autoClickLevel > 0)
        {
            Manager.instance.objectReader.FabricObject();
            yield return new WaitForSecondsRealtime(autoClickPerSecond);
        }
    }

    //permet d'améliorer le gain de monnaie des objets vendus
    public void UpgradeGain()
    {
        if (Manager.instance.score >= upgradeGainCost)
        {
            Manager.instance.score -= upgradeGainCost;
            Manager.instance.objectReader.coinMultiplicator *= 1.5f;
            upgradeGainCost = (int)(upgradeGainCost * 1.4f);
            
        }
    }

    //permet de changer les poids des objets
    public void UpgradeNewObject()
    {
        if (Manager.instance.score >= upgradeNewObjectCost && _countObjectOrder == 3)
        {
            upgradeNewObjectLevel++;
            Manager.instance.score -= upgradeNewObjectCost;
            upgradeNewObjectCost = (int)(Mathf.Pow(upgradeNewObjectCost, 1.2f));
            //Manager.instance.objectReader.objectList.Add(_shovel, 2);
            Manager.instance.objectReader.objectList.SetWeightOfObject(_or.objectList[_countObjectOrder], 18);
            _countObjectOrder++;
            //RiseCounter();
            //Debug.Log(_counter);
            Manager.instance.objectsAppearAnimation.ShovelAppearAnimationStart();
        }
        else if (Manager.instance.score >= upgradeNewObjectCost && _countObjectOrder == 4)
        {
            upgradeNewObjectLevel++;
            Manager.instance.score -= upgradeNewObjectCost;
            upgradeNewObjectCost = (int)(Mathf.Pow(upgradeNewObjectCost, 1.2f));
            Manager.instance.objectReader.objectList.SetWeightOfObject(_or.objectList[_countObjectOrder], 15);
            _countObjectOrder++;
            Manager.instance.objectsAppearAnimation.AncientPaperAppearAnimationStart();
        }
        else if (Manager.instance.score >= upgradeNewObjectCost && _countObjectOrder == 5)
        {
            upgradeNewObjectLevel++;
            Manager.instance.score -= upgradeNewObjectCost;
            Manager.instance.objectReader.objectList.SetWeightOfObject(_or.objectList[_countObjectOrder], 8);
            Manager.instance.objectsAppearAnimation.OrbAppearAnimationStart();
            _countObjectOrder = 0;
            _panelMaxUpgrade.SetActive(true);
        }

    }


    private void OnGUI()
    {
        //GUI.Label(new Rect(10,10,100,20), upgradeGainCost.ToString());
    }
}
