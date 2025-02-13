using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ResetDisplayCitizenInfo : MonoBehaviour
{
    public TMP_Text displayInfoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetTextBoxCitizen(){
        displayInfoText.gameObject.SetActive(false);
    }
        public void hideThisButton(){
        gameObject.SetActive(false);
    }
}
