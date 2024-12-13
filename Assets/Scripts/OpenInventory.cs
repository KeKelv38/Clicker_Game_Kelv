using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpeningInventory()
    {
        this.gameObject.SetActive(true);
        _animator.SetTrigger("OpenInventoryTrigger");
    }

    public void ClosingInventory()
    {
        _animator.SetTrigger("CloseInventoryTrigger");
        
    }
}
