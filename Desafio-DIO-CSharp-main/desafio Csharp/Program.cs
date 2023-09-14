
using desafio_Csharp.src.Entities;

Warrior Arus = new Warrior("Arus", 12, 120, 21);

Wizard Jennica = new Wizard("Jennica", 12, 90, 23);

Enemy enemy1 = new Enemy("Damon", 15, 50);
Enemy enemy2 = new Enemy("Worm", 10, 35);
Enemy enemy3 = new Enemy("Orc", 20, 60);

bool herosLive = true;
bool enemyLive = true;

Hero[] heros = new Hero[] { Arus, Jennica };

Enemy[] enemys = new Enemy[] { enemy1, enemy2, enemy3 };

while(herosLive && enemyLive)
{

    Console.WriteLine(Arus.Name + " possui " + Arus.HP + " de HP");
    Console.WriteLine(Jennica.Name + " possui " + Jennica.HP + " de HP");
    Console.WriteLine("Damon1 possui " + enemy1.HP + " de HP");
    Console.WriteLine("Damon2 possui " + enemy2.HP + " de HP");
    Console.WriteLine("Orc possui " + enemy3.HP + " de HP");
    Console.WriteLine("------------------------------------------------------");


    foreach (Enemy enemy in enemys)
    {
        if (!enemy.IsDead)
        {
            if (!Arus.IsDead)
            {
                Console.WriteLine(enemy.Attack(Arus));
                Console.WriteLine("------------------------------------------------------");
            }
            else if (!Jennica.IsDead)
            {
                Console.WriteLine(enemy.Attack(Jennica));
                Console.WriteLine("------------------------------------------------------");
            }

        }
    }

    foreach(Hero hero in heros)
    {
        if (!hero.IsDead)
        {
            if (!enemy1.IsDead)
            {
                Console.WriteLine(hero.Attack(enemy1));
                Console.WriteLine("------------------------------------------------------");
            }
            else if (!enemy2.IsDead)
            {
                Console.WriteLine(hero.Attack(enemy2));
                Console.WriteLine("------------------------------------------------------");
            }
            else if (!enemy3.IsDead)
            {
                Console.WriteLine(hero.Attack(enemy3));
                Console.WriteLine("------------------------------------------------------");
            }

        }

    }

    enemyLive = !enemy1.IsDead || !enemy2.IsDead || !enemy3.IsDead;
    herosLive = !Arus.IsDead || !Jennica.IsDead;
}
