using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
  [SerializeField] private GameObject animStone;
  [SerializeField] private GameObject dialogue_2;

  void OnMouseDown()
  {
    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
      Debug.Log("Touch");
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
      if (hit.collider != null && hit.collider.gameObject == gameObject)
      {
        animStone.SetActive(true);
        Invoke("UIWindow",2);
      }
    }
  }

  void UIWindow()
    {
      dialogue_2.SetActive(true);
    }
}
