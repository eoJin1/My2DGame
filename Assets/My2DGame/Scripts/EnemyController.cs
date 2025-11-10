using UnityEngine;
namespace My2DGame
{
    /// <summary>
    /// Enemy를 관리하는 클래스
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D),(typeof(TouchingDirections)))]
    public class EnemyController : MonoBehaviour
    {
        #region Variables
        //참조
        private Rigidbody2D rb2D;
        private TouchingDirections touchingDirections;
        private Animator animator;

        //이동
        //이동 속도
        [SerializeField] private float runSpeed = 4f; 
        //이동 방향
        private Vector2 directionVector = Vector2.right;
        //이동 가능한 방향 정의
        public enum WalkableDirection
        {
            Left,
            Right
        }
        //현재 이동 방향
        private WalkableDirection walkDirection = WalkableDirection.Right;
        #endregion

        #region Property
        public WalkableDirection WalkDirection
        {
            get { return walkDirection; }
            private set 
            { 
                //방향 전환이 일어난 시점
                if(walkDirection != value)
                {
                    //이미지 플립
                    transform.localScale *= new Vector2(-1, 1);

                    //value값에 따라 이동 방향 설정
                    if(value == WalkableDirection.Left)
                    {
                        directionVector = Vector2.left;
                    }
                    else if(value == WalkableDirection.Right)
                    {
                        directionVector = Vector2.right;
                    }
                }


                walkDirection = value; 
            }
        }
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
            touchingDirections = this.GetComponent<TouchingDirections>();
            animator = this.GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            //벽 체크
            if(touchingDirections.IsWall && touchingDirections.IsGround)
            {
                Flip();
            }

            //이동하기
            rb2D.linearVelocity = new Vector2(directionVector.x * runSpeed, rb2D.linearVelocityY);
        }
        #endregion

        #region Custom Method
        //방향 전환
        void Flip()
        {
            if(walkDirection == WalkableDirection.Left)
            {
                walkDirection = WalkableDirection.Right;
            }
            else if(walkDirection == WalkableDirection.Right)
            {
                walkDirection = WalkableDirection.Left;
            }
            else
            {
                Debug.Log("Error Flip");
            }
        }
        #endregion
    }
}