using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
  [SerializeField] private GameObject button;
  //[SerializeField] private GameObject window;
  [SerializeField] private GameObject startFight;
  [SerializeField] private GameObject joystick;
  public CinemachineVirtualCamera vcam;
  private Transform player;
  private Transform target;
  private bool isFollowingPlayer = true;


  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Link").transform;
    target = GameObject.FindGameObjectWithTag("Fight").transform;
  }

  void SwitchCameraTarget()
  {
    button.SetActive(false);
    joystick.SetActive(false);
    //window.SetActive(true);
    startFight.SetActive(true);
    isFollowingPlayer = !isFollowingPlayer;
    if (isFollowingPlayer)
    {
      vcam.Follow = player;
      vcam.m_Lens.OrthographicSize = 5f;
    }
    else
    {
      vcam.Follow = target;
      vcam.m_Lens.OrthographicSize = 8f;
    }
  }
}
