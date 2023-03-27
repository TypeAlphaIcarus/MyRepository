using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Car
{
    /// <summary>
    /// 车辆控制
    /// </summary>
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float acceleration;    //加速度
        [SerializeField] private float turnSpeed;       //转向速度

        public Transform carModelTransform;             //车辆网格模型
        private Vector3 startModelOffset;

        [SerializeField] private float groundCheckRate; //地面检测频率
        private float lastGroundCheckTime;              //上一次地面检测的时间

        private float currentYRotation;                 //当前转向角度

        //键盘/控制器输入
        private bool accelerateInput;       //加速输入
        private float turnInput;            //转向输入

        [SerializeField] private Rigidbody rig;

        private void Start()
        {
            startModelOffset = carModelTransform.transform.localPosition;
        }

        private void FixedUpdate()
        {
            if (accelerateInput == true)
            {
                rig.AddForce(carModelTransform.forward * acceleration, ForceMode.Acceleration);
            }
        }

        private void Update()
        {
            Debug.Log("Accelerating: " + accelerateInput);
            Debug.Log("Turn: " + turnInput);

            //漂移效果，使用速度方向点乘前方，偏移量越大，乘积越小，转向变化越慢
            //同时防止车静止时可以原地转圈
            float turnRate = Vector3.Dot(rig.velocity.normalized, carModelTransform.forward);
            turnRate = Mathf.Abs(turnRate);

            currentYRotation += turnInput * turnSpeed * turnRate * Time.deltaTime;

            carModelTransform.position = transform.position + startModelOffset;
            carModelTransform.eulerAngles = new Vector3(0, currentYRotation, 0);

        }

        public void OnAccelerateInput(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.phase == InputActionPhase.Performed)
                accelerateInput = true;
            else
                accelerateInput = false;
        }

        public void OnTurnInput(InputAction.CallbackContext callbackContext)
        {
            turnInput = callbackContext.ReadValue<float>();
        }

    }
}
