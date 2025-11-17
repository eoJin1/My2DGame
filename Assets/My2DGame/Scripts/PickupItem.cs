using UnityEngine;

namespace My2DGame
{
    /// <summary>
    /// 맵에 떨어진 아이템을 픽업하는 기능
    /// 픽업시 아이템 효과 구현, 아이템 회전
    /// </summary>
    public class PickupItem : MonoBehaviour
    {
        #region Variables
        //아이템 효과 정보 - hp 회복
        [SerializeField]
        private float healthRestore = 10f;

        //아이템 회전 연출
        [SerializeField]
        private Vector3 rotationSpeed = new Vector3(0f, 180f, 0f);
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //회전
            this.transform.eulerAngles += Time.deltaTime * rotationSpeed;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            //아이템 픽업
            bool isPickup = Pickup(collision);
            if (isPickup)
            {
                Destroy(gameObject);
            }   
        }
        #endregion

        #region Custom Method
        //픽업시 아이템 효과 구현, 픽업 성공시 true, 실패시 false; - hp 회복
        protected virtual bool Pickup(Collider2D collision)
        {
            bool isUse = false;

            Damageable damageable = collision.GetComponent<Damageable>();

            if (damageable != null)
            {
                isUse = damageable.Heal(healthRestore);
            }

            return isUse;
        }

        //아이템을 회전 시킨다

        #endregion
    }
}