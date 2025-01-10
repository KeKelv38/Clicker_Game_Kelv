using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuitOpen : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private bool _quitIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //pour faire apparaitre un petit menu avec le bouton quit qui ferme le jeu
    public void OpeningOrClosingQuit()
    {
        if (_quitIsOpen == false)
        {
            _animator.SetTrigger("QuitOpen");
            _quitIsOpen = true;
        }
        else
        {
            _animator.SetTrigger("QuitClose");
            _quitIsOpen = false;
        }
    }
}
