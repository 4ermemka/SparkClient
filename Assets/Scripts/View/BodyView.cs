using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyView : MonoBehaviour
{
    [SerializeField]
    public List<Color> ColorGradient = new List<Color>();

    [SerializeField]
    private Image HeadDisplay;
    [SerializeField]
    private Image BodyDisplay;
    [SerializeField]
    private Image LeftArm;
    [SerializeField]
    private Image RightArm;
    [SerializeField]
    private Image LeftLeg;
    [SerializeField]
    private Image RightLeg;

}
