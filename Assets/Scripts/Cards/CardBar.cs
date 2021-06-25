using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBar : MonoBehaviour
{
	public Slider slider;

	public void SetMaxValue(int maxValue)
	{
		slider.maxValue = maxValue;
		slider.value = 0;
	}

	public void SetValue(int value)
	{
		slider.value = value;
	}
}
