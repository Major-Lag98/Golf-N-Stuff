using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
   int n;
   public Text myText;
   public Slider mySlider;
   void Update() {
      myText.text = "Current Volume: " + mySlider.value;
   }
}
