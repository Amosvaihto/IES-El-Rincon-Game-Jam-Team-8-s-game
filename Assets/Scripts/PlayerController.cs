using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct CreatureItemStruct
{
    public string name;
    public GameObject prefab;
}

public class PlayerController : MonoBehaviour
{

    public int mana = 100;
    public int manaMax = 100;
    public LayerMask gridLayer;
    public string selectedCreature = "";
    public TextMeshProUGUI selectedCreatureText;
    public TextMeshProUGUI manaText;
    public List<CreatureItemStruct> creatureItems;

    private void Start()
    {
        manaText.text = "Mana: " + mana + "/" + manaMax;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !selectedCreature.Equals(""))
        {
            Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(posicionMouse, Vector2.zero, Mathf.Infinity, gridLayer);
            if (hit.collider != null && hit.collider.gameObject.transform.childCount == 0)
            {
                Transform hitTransform = hit.collider.gameObject.transform;
                Instantiate(GetCreatureSelected(), new Vector2(hitTransform.position.x, hitTransform.position.y), Quaternion.identity, hitTransform);
            }
        }
    }

    public void ChangeSelectedCreature(string creature)
    {
        selectedCreature = creature;
        selectedCreatureText.text = "Criatura seleccionada: " + creature;
    }

    public GameObject GetCreatureSelected()
    {
        return creatureItems.Find(element => element.name == selectedCreature).prefab;
    }
}
