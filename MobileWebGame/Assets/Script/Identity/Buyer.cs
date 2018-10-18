using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="People", menuName = "Object/Buyer")]
public class Buyer : ScriptableObject {

    public new string Names;
    public Sprite Icon;

    public int identityInt;

    public float MaxService;
    public float ChanceOfTip;
    public float Tip;

    public float ProbabilityBuy;
    public float RangeQuantity;

    public int IndexTypeMenu;
}
