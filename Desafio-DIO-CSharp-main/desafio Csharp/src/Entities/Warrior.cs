
namespace desafio_Csharp.src.Entities
{
    internal class Warrior : Hero
    {

        public override string Attack(Enemy enemy)
        {
            enemy.HP -= this.MP;
            if (enemy.HP <= 0)
            {
                enemy.HP = 0;
                enemy.IsDead = true;
                return this.Name + " Matou seu adiversário";
            }
            return this.Name + " Atacou com sua espada";
        }

        public Warrior(string Name, int Level, int HP, int MP)
        {
            this.Name = Name;
            this.Level = Level;
            this.HP = HP;
            this.MP = MP;
        }
    }
}
