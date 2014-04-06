﻿using UnityEngine;

public class ButtonSelectTruck : MonoBehaviour
{
  [SerializeField] private CarCameras carcameras = null;
  [SerializeField] private Steer steer = null;
  [SerializeField] private Button2D buttonBrake = null;
  [SerializeField] private Button2D buttonNitro = null;
  [SerializeField] private ButtonTuning buttonTuning = null;
  [SerializeField] private Transform pos = null;
  [SerializeField] private GameObject[] trucks = null;
  [SerializeField] private int id = 0;

  protected virtual void OnPress(bool isPressed)
  {
    if (!isPressed)
    {
      GameObject truck = Instantiate(trucks[id], pos.position, Quaternion.identity) as GameObject;
      if (truck != null)
      {
        CameraTarget cts = truck.GetComponentInChildren<CameraTarget>();  //Находим трейлер, на который будет нацелена камера
        if (cts != null)
        {
          carcameras.target = cts.transform;
          AxisCarController aCC = cts.GetComponent<AxisCarController>();
          steer.axisCarController = aCC;
          buttonBrake.axisCarController = aCC;
          buttonNitro.axisCarController = aCC;
          buttonTuning.drivetrain = cts.GetComponent<Drivetrain>();
          buttonTuning.setup = cts.GetComponent<Setup>();
        }
        else
        {
          Debug.LogWarning("CameraTarget was not found");
        }
      }
      else
      {
        Debug.LogWarning("truck = NULL");
      }
    }
	}
}

