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
    //fait apparaitre la liste des objets que le joueur peut craft
    public void OpeningInventory()
    {
        _animator.SetTrigger("OpenInventoryTrigger");
    }

    public void ClosingInventory()
    {
        _animator.SetTrigger("CloseInventoryTrigger");
        
    }
}
