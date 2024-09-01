using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data",menuName ="Data/destinations")]
public class Places : ScriptableObject
{
    public Vector2d destinationCoordinate_1 = new();
    public Vector2d destinationCoordinate_2 = new();
    public Vector2d[] destinationCoordinates;


}
