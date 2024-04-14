using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    // Start is called before the first frame update
   private void Start()
    {
        GameObject.Instantiate(Resources.Load("Menut/Asetukset"));
        GameObject Asetukset = GameObject.Find("Asetukset(Clone)");
        Destroy(Asetukset);

        GameObject.Instantiate(Resources.Load("Menu/Mainmenu"));
    }

}
