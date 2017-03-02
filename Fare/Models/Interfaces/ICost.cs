namespace Fare.Models.Interfaces
{
    public interface ICost
    {
        decimal BaseFee { get; }
        decimal Tax { get; }
        decimal Rate { get; }
        decimal PerMinute { get; }
        decimal PerDistance { get; }
        decimal NightTimeRate { get; }
        decimal PeakCost { get; }
    }
}
