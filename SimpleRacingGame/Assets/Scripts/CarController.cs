using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Car
{
    /// <summary>
    /// ��������
    /// </summary>
    public class CarController : MonoBehaviour
    {
        [SerializeField] private float acceleration;    //���ٶ�
        [SerializeField] private float turnSpeed;       //ת���ٶ�

        public Transform carModelTransform;             //��������ģ��
        private Vector3 startModelOffset;

        [SerializeField] private float groundCheckRate; //������Ƶ��
        private float lastGroundCheckTime;              //��һ�ε������ʱ��

        private float currentYRotation;                 //��ǰת��Ƕ�

        //����/����������
        private bool accelerateInput;       //��������
        private float turnInput;            //ת������

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

            //Ư��Ч����ʹ���ٶȷ�����ǰ����ƫ����Խ�󣬳˻�ԽС��ת��仯Խ��
            //ͬʱ��ֹ����ֹʱ����ԭ��תȦ
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
