using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ObjectReader : MonoBehaviour
{
    private int _currentStep;

    [SerializeField]
    private TextMeshProUGUI _nameText, _baseStepText, _categoryText, _priceText;

    [SerializeField]
    private Image _objectImage;

    [SerializeField]
    public ObjectToFabric currentObject;

    [SerializeField]
    public WeightedList<ObjectToFabric> objectList;

    [SerializeField]
    private Image _stepGauge;
    [SerializeField]
    private float _stepGaugeMax;

    

    public float coinMultiplicator = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //ReadObject(objectList[Random.Range(0, objectList._weightedElementsList.Count)]);
        ReadObject(objectList.GetRandomElement());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //lis l'objet et ses infos
    private void ReadObject(ObjectToFabric newObject)
    {
        currentObject = newObject;

        _currentStep = currentObject.baseStep;

        _nameText.text = currentObject.objectName.ToString();
        _baseStepText.text = currentObject.baseStep.ToString("00");
        _categoryText.text = currentObject.category.ToString();
        _priceText.text = currentObject.coinGain.ToString("00");

        _objectImage.sprite = currentObject.objectImage;
        _stepGauge.fillAmount = 0;
    }
    
    //cliquer pour réduire le nombre de step de création en fonction de la puissance du clic
    public void FabricObject()
    {
        _currentStep -= (int)Manager.instance.powerClick;
        _baseStepText.text = _currentStep.ToString("00");
        _stepGauge.fillAmount = 1 - ((float)_currentStep / (float)currentObject.baseStep);

        Manager.instance.juicyEffect.FabricObjectAnimation();

        

        if (_currentStep <= 0)
        {
            StartCoroutine(StepGaugeWait());
            Manager.instance.score += (int)(currentObject.coinGain * coinMultiplicator);
            Debug.Log (currentObject.coinGain);

            //ReadObject(objectList[Random.Range(0, objectList._weightedElementsList.Count)]);
            ReadObject(objectList.GetRandomElement());
        }
    }






    //ca marche pas ca 
    public IEnumerator StepGaugeWait()
    {
        yield return new WaitForSecondsRealtime(1);
    }
}
