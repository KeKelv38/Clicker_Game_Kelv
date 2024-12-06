using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindFirstObjectByType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeClick()
    {
        manager.score -= 50;
        manager.powerClick = manager.powerClick * 2;
    }
}
