
namespace desafio_Csharp.src.Entities
{
    internal class Enemy
    {
        public string Type { get; set; }

        public int Damage { get; set; }

        public int HP { get; set; }

        public bool IsDead { get; set; } = false;

        public Enemy(string Type, int Damage, int HP)
        {
            this.Type = Type;
            this.Damage = Damage;
            this.HP = HP;
        }

        public virtual string Attack(Hero hero)
        {
            hero.HP -= this.Damage;

            if (hero.HP <= 0)
            {
                hero.HP = 0;
                hero.IsDead = true;
                return hero.Name + " Morreu";
            }
            return this.Type + " causou " + this.Damage + " de dano em " + hero.Name;
        }

    }
}
