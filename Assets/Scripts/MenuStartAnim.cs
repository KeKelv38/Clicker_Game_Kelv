using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStartAnim : MonoBehaviour
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

    public void StartingGame()
    {
        _animator.SetTrigger("StartingGameTrigger");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
