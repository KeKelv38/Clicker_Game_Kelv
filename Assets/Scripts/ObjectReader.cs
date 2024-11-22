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
    private Sprite _objectImage;

    [SerializeField]
    private ObjectTofabric _currentObject;

    [SerializeField]
    private ObjectTofabric[] _objectList;


    // Start is called before the first frame update
    void Start()
    {

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

        _objectImage = _currentObject.objectImage;

    }

    public void FabricObject()
    {
        _currentStep = -1;
        _baseStepText.text = _currentStep.ToString("000");

        if (_currentStep <= 0)
        {

        }
    }
}
