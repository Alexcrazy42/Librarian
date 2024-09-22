namespace Domain.Enums;

/// <summary>
/// Статус запроса на аренду книг
/// </summary>
public enum RentRequestStatus
{
    /// <summary>
    /// Нет ответа
    /// </summary>
    None,

    /// <summary>
    /// Подтверждено
    /// </summary>
    Accept,

    /// <summary>
    /// Отклонено
    /// </summary>
    Reject,

    /// <summary>
    /// Готовы дать часть книг
    /// </summary>
    ReadyGivePartOfBooks
}