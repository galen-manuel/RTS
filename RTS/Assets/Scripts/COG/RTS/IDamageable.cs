using COG.RTS.Units;

public interface IDamageable
{
    void TakeDamage(string pSource, float pAmount, DamageType pDamageType);
}
