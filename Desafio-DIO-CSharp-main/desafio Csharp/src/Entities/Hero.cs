using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio_Csharp.src.Entities
{
    abstract internal class Hero
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public bool IsDead { get; set; } = false;

        public abstract string Attack(Enemy enemy);
    }
}
