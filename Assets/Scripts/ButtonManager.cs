using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
   int n;
   public Text myText;
   public Slider mySlider;
   void Update() 
   {
        myText.text = "Current Volume: " + mySlider.value;
   }
}
