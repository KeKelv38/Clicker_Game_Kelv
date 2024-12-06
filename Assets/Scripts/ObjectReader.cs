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
    private ObjectTofabric _currentObject;

    [SerializeField]
    private ObjectTofabric[] _objectList;

    [SerializeField]
    private Image stepGauge;
    [SerializeField]
    private float _stepGaugeMax;

    public Manager manager;


    // Start is called before the first frame update
    void Start()
    {
        ReadObject(_objectList[Random.Range(0, _objectList.Length)]);

        manager = FindFirstObjectByType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReadObject(ObjectTofabric newObject)
    {
        _currentObject = newObject;

        _currentStep = _currentObject.baseStep;

        _nameText.text = _currentObject.objectName.ToString();
        _baseStepText.text = _currentObject.baseStep.ToString("00");
        _categoryText.text = _currentObject.category.ToString();

        _objectImage.sprite = _currentObject.objectImage;
        stepGauge.fillAmount = 0;
    }

    public void FabricObject()
    {
        _currentStep -= (int)manager.powerClick;
        _baseStepText.text = _currentStep.ToString("00");
        stepGauge.fillAmount = 1 - ((float)_currentStep / (float)_currentObject.baseStep);

        if (_currentStep <= 0)
        {
            manager.score += _currentObject.coinGain;
            Debug.Log (_currentObject.coinGain);

            ReadObject(_objectList[Random.Range(0, _objectList.Length)]);
        }
    }
}
