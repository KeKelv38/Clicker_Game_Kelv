using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuicyEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonFabric;

    [SerializeField]
    private Animator _animatorFabric;

    // Start is called before the first frame update
    void Start()
    {
        _buttonFabric = GameObject.Find("ObjectButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FabricObjectAnimation()
    {
        _animatorFabric.SetTrigger("OnClick");

    }
}
