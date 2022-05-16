using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LineRenderer))]
public class Player : MonoBehaviour
{
   public CinemachineVirtualCameraBase PlayerCamera;
   public Camera MainCamera;
   public float MaxForce = 1.5f;
   public float ForceAcceleration = 1.5f;
   public Color MinForceColor = Color.green;
   public Color MaxForceColor = Color.red;
   
   private Rigidbody _rigidbody;
   private LineRenderer _lineRenderer;
   private float _currentForce;
   private float _pingPongTime;
   public bool _canShoot;
   

   private void Awake()
   {
      Cursor.lockState = CursorLockMode.Locked;
      
      _rigidbody = GetComponent<Rigidbody>();
      _lineRenderer = GetComponent<LineRenderer>();

      _lineRenderer.enabled = false;
   }

   public void SpawnTo(Vector3 point)
   {
      _rigidbody.MovePosition(point);
   }

   private void Update()
   {
      _canShoot = _rigidbody.velocity.magnitude < 0.1f;

      if (!_canShoot)
      {
         return;
         
      }

      _rigidbody.velocity = Vector3.zero;
      _rigidbody.angularVelocity = Vector3.zero;
      
      ProcessOnMouseDown();
      ProcessOnMouseUp();
      ProcessOnMouseHold();
   }

   private void ProcessOnMouseDown()
   {
      if (Input.GetMouseButtonDown(0))
      {
         PlayerCamera.gameObject.SetActive(true);

         _lineRenderer.SetPosition(0, transform.position);
         _lineRenderer.enabled = true;

         _currentForce = 0;
         _pingPongTime = 0;
      }
   }
   
   private void ProcessOnMouseUp()
   {
      if (Input.GetMouseButtonUp(0))
      {
         PlayerCamera.gameObject.SetActive(true);
         _lineRenderer.enabled = false;

         var cameraForward = MainCamera.transform.forward;
         var forceDirection = new Vector3(cameraForward.x, 0, cameraForward.z) * _currentForce;
         
         _rigidbody.AddForce(forceDirection, ForceMode.Impulse);
      }
   }
   
   private void ProcessOnMouseHold()
   {
      if (Input.GetMouseButton(0))
      {
         _pingPongTime += Time.deltaTime;
         _currentForce = Mathf.PingPong(ForceAcceleration * _pingPongTime, MaxForce);
         
         var cameraForward = MainCamera.transform.forward;
         var playerPosition = transform.position;
         var newPosition = playerPosition + new Vector3(
            cameraForward.x,
            0,
            cameraForward.z
         ) * _currentForce;
         _lineRenderer.SetPosition(1, newPosition);
         _lineRenderer.startColor = _lineRenderer.endColor = Color.Lerp(MinForceColor, MaxForceColor, _currentForce);
      }
      {
         
      }
   }
}
