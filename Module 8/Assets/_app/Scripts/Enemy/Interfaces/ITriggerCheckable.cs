namespace _app.Scripts.Enemy.Interfaces
{
    public interface ITriggerCheckable
    {
        bool IsAggroed { get; set; }
        bool IsWithinStrikingDistance { get; set; }

        void SetAggroStatus(bool isAggroed);
        void SetStrikingDistanceBool(bool isWithinStrickingDistance);
    }
}
