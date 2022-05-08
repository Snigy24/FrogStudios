public interface IHealth : IDamageable
{
        public int Health { get; }

        public void Heal(int amount);
}