namespace Domain.Enums;

/// <summary>
/// Назначение учебной литературы
/// </summary>
public enum Appointment
{
    Unknown = 0,

    /// <summary>
    /// Учебник
    /// </summary>
    Textbook,

    /// <summary>
    /// Пособие
    /// </summary>
    Allowance,

    /// <summary>
    /// Атлас
    /// </summary>
    Atlas,

    /// <summary>
    /// Кодекс
    /// </summary>
    Code,

    /// <summary>
    /// Методичка
    /// </summary>
    Manual
}
