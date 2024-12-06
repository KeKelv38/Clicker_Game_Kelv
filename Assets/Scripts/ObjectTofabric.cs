using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", order = 0)]

public class ObjectTofabric : ScriptableObject
{
    public string objectName;
    public int baseStep;

    public ObjectCategory category;

    public Sprite objectImage;

    public int coinGain;

}
