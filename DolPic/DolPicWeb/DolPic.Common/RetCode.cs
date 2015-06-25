
namespace DolPic.Common
{
    /// <summary>
    /// DB 결과값 enum
    /// </summary>
    public enum e_RetCode
    {
        /// <summary>
        /// 정상 등록 0
        /// </summary>
        success = 0,
        /// <summary>
        /// 중복 1
        /// </summary>
        has = 1,
        /// <summary>
        /// 이벤트 종료 2
        /// </summary>
        event_over = 2,
        /// <summary>
        /// 조건 불일치 3
        /// </summary>
        discord = 3,
        /// <summary>
        /// 불인증 4
        /// </summary>
        not_auth = 4,
        /// <summary>
        /// 이벤트 제한 유저 5
        /// </summary>
        refuse_user = 5,
        /// <summary>
        /// 아이템이 없는 경우 6
        /// </summary>
        item_over = 6,
        /// <summary>
        /// 이미 사용 8
        /// </summary>
        already_use = 8,
        /// <summary>
        /// 없는 경우 9
        /// </summary>
        no_has = 9,
        /// <summary>
        /// 선착순 마감 10
        /// </summary>
        order_end = 10,
        /// <summary>
        /// 미사용 11
        /// </summary>
        no_use = 11,
        /// <summary>
        /// 미신청 12
        /// </summary>
        no_reg = 12,
        /// <summary>
        /// 포인트나 돈이 없는 경우 13
        /// </summary>
        no_point = 13,
        /// <summary>
        /// 레퍼러 오류 98
        /// </summary>
        refer_error = 98,
        /// <summary>
        /// DB 에러 99
        /// </summary>
        db_error = 99
    }
}
