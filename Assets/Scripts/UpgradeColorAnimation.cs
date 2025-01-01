using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeColorAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator1;
    [SerializeField]
    private Animator _animator2;
    [SerializeField]
    private Animator _animator3;
    [SerializeField]
    private Animator _animator4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //quand le score est > au prix de l'amélioration alors le bouton s'affiche en vert, pour les upgrades 1 à 4
        if (Manager.instance.score > Manager.instance.upgrade1.upgradeClickCost)
        {
            _animator1.SetBool("Upgrade1ColorBool", true);
        }
        else
        {
            _animator1.SetBool("Upgrade1ColorBool", false);
        }
        //-----------------------------------------------------------------------------------

        if (Manager.instance.score > Manager.instance.upgrade1.upgradeAutoClickCost)
        {
            _animator2.SetBool("Upgrade2ColorBool", true);
        }
        else
        {
            _animator2.SetBool("Upgrade2ColorBool", false);
        }
        //-----------------------------------------------------------------------------------

        if (Manager.instance.score > Manager.instance.upgrade1.upgradeGainCost)
        {
            _animator3.SetBool("Upgrade3ColorBool", true);
        }
        else
        {
            _animator3.SetBool("Upgrade3ColorBool", false);
        }
        //-----------------------------------------------------------------------------------

        if (Manager.instance.score > Manager.instance.upgrade1.upgradeNewObjectCost)
        {
            _animator4.SetBool("Upgrade4ColorBool", true);
        }
        else
        {
            _animator4.SetBool("Upgrade4ColorBool", false);
        }


    }
}
