namespace EF.Models.Enums;

public enum OrderStatus
{
    Received = 1,      // Bestellung erhalten
    Confirmed = 2,     // Bestätigt
    Preparing = 3,     // In Zubereitung
    Baking = 4,        // Im Ofen
    Ready = 5,         // Fertig/Abholbereit
    OutForDelivery = 6,// Unterwegs
    Delivered = 7,     // Zugestellt
    Cancelled = 8      // Storniert
}