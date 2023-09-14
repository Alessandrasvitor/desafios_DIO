using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_Csharp.src.Entities
{
    internal class Wizard : Hero
    {

        public string Attack(Enemy enemy, int Bonus)
        {
            enemy.HP -= (this.MP + Bonus);

            if (Bonus > 6)
            {
                return this.Name + " Lançou uma magia super efetiva";
            }

            if (enemy.HP <= 0)
            {
                enemy.HP = 0;
                enemy.IsDead = true;
                return this.Name + " Matou seu adiversário";
            }
            return this.Name + " Lançou magia efetiva";
        }

        public override string Attack(Enemy enemy)
        {
            enemy.HP -= this.MP;
            if (enemy.HP <= 0)
            {
                enemy.HP = 0;
                enemy.IsDead = true;
                return this.Name + " Matou seu adiversário";
            }
            return this.Name + " Lançou magia";
        }

        public Wizard(string Name, int Level, int HP, int MP)
        {
            this.Name = Name;
            this.Level = Level;
            this.HP = HP;
            this.MP = MP;
        }


    }
}
