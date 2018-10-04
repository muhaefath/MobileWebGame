using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="People", menuName ="Buyer")]
public class Buyer : ScriptableObject {

    public new string Names;
    public Sprite Icon;

    public int identityInt;
}
