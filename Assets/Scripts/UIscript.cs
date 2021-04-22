using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.
// using UnityEngine.UIElements;


// Creating UI elements from scripting 
// https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/HOWTO-UICreateFromScripting.html

// https://docs.unity3d.com/2020.1/Documentation/Manual/UI-system-compare.html

public class UIscript : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public GameObject canvas;
    public GameObject togglePrefab;
    public GameObject sliderPrefab;
    



    // Start is called before the first frame update
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
      
      // https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
      CreateIntManipulator(30,100,0);
      CreateBoolManipulator(false, "toggle1", 1);
      CreateBoolManipulator(true, "toggle2", 2)
    }


    void CreateButtonToggle() {
      // Instantiate at position (0, 0, 0) and zero rotation.
      GameObject buttonUI = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
      buttonUI.transform.SetParent(canvas.transform, false);
    }

    void CreateIntManipulator(int value, int max, int min) {
      // Instantiate at position (0, 0, 0) and zero rotation.
      GameObject UIsliderObject = Instantiate(sliderPrefab, new Vector3(0, 0, 0), Quaternion.identity);
      UIsliderObject.transform.SetParent(canvas.transform, false);
      // Component[] list = UIsliderObject.GetComponents(typeof(Slider));
      // Dit werk alleen met UnityEngine.UI niet UnityEngine.UIElements
      Slider slider = (Slider) UIsliderObject.GetComponent(typeof(Slider));// as Slider;
      // UIslider
      slider.maxValue = max;
      slider.minValue = min;
      slider.value = value;
      slider.wholeNumbers = true;
    }

    void CreateBoolManipulator(bool value, String label, int yvalue) {
      GameObject UItoggleObject = Instantiate(togglePrefab, new Vector3(0, yvalue, 0), Quaternion.identity);
      UItoggleObject.transform.SetParent(canvas.transform, false);

      Toggle toggle = (Toggle) UItoggleObject.GetComponent(typeof(Toggle));

      toggle.value = value;
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    // This is the transform of the prefab not the instantiated object
    // myPrefabTransform = myPrefab.transform; 
    // .GetComponent<Transform>() is slower than .transform
}
