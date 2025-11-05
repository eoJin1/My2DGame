using UnityEngine;
using UnityEngine.InputSystem;
namespace My2DGame
{
    /// <summary>
    /// 플레이어를 제어하는 클래스
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        //참조
        private Rigidbody2D rb2D;

        //이동
        [SerializeField]
        private float walkSpeed = 1.0f;

        //입력 값
        private Vector2 inputMove = Vector2.zero;
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            //이동
            rb2D.linearVelocity = new Vector2(inputMove.x * walkSpeed, rb2D.linearVelocity.y);
        }

        #endregion

        #region Custom Method
        public void OnMove(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
            Debug.Log(inputMove);
        }
        #endregion
    }
}
