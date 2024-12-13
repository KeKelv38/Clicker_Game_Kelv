using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectReader : MonoBehaviour
{
    private int _currentStep;

    [SerializeField]
    private TextMeshProUGUI _nameText, _baseStepText, _categoryText;

    [SerializeField]
    private Image _objectImage;

    [SerializeField]
    public ObjectTofabric currentObject;

    [SerializeField]
    private ObjectTofabric[] _objectList;

    [SerializeField]
    private Image _stepGauge;
    [SerializeField]
    private float _stepGaugeMax;

    

    public float coinMultiplicator = 1f;


    // Start is called before the first frame update
    void Start()
    {
        ReadObject(_objectList[Random.Range(0, _objectList.Length)]);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadObject(ObjectTofabric newObject)
    {
        currentObject = newObject;

        _currentStep = currentObject.baseStep;

        _nameText.text = currentObject.objectName.ToString();
        _baseStepText.text = currentObject.baseStep.ToString("00");
        _categoryText.text = currentObject.category.ToString();

        _objectImage.sprite = currentObject.objectImage;
        _stepGauge.fillAmount = 0;
    }

    public void FabricObject()
    {
        _currentStep -= (int)Manager.instance.powerClick;
        _baseStepText.text = _currentStep.ToString("00");
        _stepGauge.fillAmount = 1 - ((float)_currentStep / (float)currentObject.baseStep);

        if (_currentStep <= 0)
        {

            Manager.instance.score += (int)(currentObject.coinGain * coinMultiplicator);
            Debug.Log (currentObject.coinGain);

            ReadObject(_objectList[Random.Range(0, _objectList.Length)]);
        }
    }
}
