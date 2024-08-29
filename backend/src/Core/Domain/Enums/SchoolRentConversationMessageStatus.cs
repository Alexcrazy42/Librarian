namespace Domain.Enums;

/// <summary>
/// Статус сообщения в беседе о аренде книги между школами
/// </summary>
public enum SchoolRentConversationMessageStatus
{
    /// <summary>
    /// Простое сообщение
    /// </summary>
    Message,

    /// <summary>
    /// Подтвердение готовности аренды книг
    /// </summary>
    Accept,

    /// <summary>
    /// Отказ в аренде книг
    /// </summary>
    Reject,

    /// <summary>
    /// Готовность аренды части от желаемого количества книг
    /// </summary>
    ReadyGivePartOfBook
}
