using UnityEngine;
namespace My2DGame
{
    /// <summary>
    /// 그라운드, 천정, 벽 체크
    /// </summary>
    public class TouchingDirection : MonoBehaviour
    {
        #region Variables
        //참조
        //접촉하는 충돌체
        private CapsuleCollider2D touchingCol;

        //접촉면 범위
        [SerializeField]
        private float groundDistance = 0.05f;

        //접촉 조건
        [SerializeField]
        private ContactFilter2D contactFilter;

        //캐스트 결과
        private RaycastHit2D[] groundHits = new RaycastHit2D[5];
        private RaycastHit2D[] cellingHits = new RaycastHit2D[5];

        //
        private bool isGround;
        private bool iscelling;
        #endregion

        #region Property
        public bool IsGround
        {
            get { return isGround; }
            private set
            {
                IsGround = value;
                //animator.SetBool(AnimationString.IsGrounded, value);
            }
        }
        public bool IsCelling
        {
            get { return iscelling; }
            private set
            {
                iscelling = value;
                //애니 파라미터 셋팅
            }
        }
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            touchingCol = this.touchingCol as CapsuleCollider2D;
        }

        private void FixedUpdate()
        {
            IsGround = (touchingCol.Cast(Vector2.down, contactFilter, groundHits, groundDistance) > 0);
        }
        #endregion
    }
}