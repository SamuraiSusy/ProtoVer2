using UnityEngine;
using System.Collections;

public class ScreenSettings : MonoBehaviour
{
	void Start ()
    {
        Screen.SetResolution(640, 480, false);
	}
}