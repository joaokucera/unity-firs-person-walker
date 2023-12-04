namespace Assets.Scripts.GAME.Entity
{
    public interface IEntitySettings
    {
        public string Name { get; }
        public bool IsPlayer { get; }
        public bool IsImmortal { get; }
        public bool IsImmuneToPoison { get; }
        public int MaxHealth { get; }
    }
}
