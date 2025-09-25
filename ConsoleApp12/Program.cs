using System;
using System.Collections.Generic;
using System.Linq;

class FootballTeam
{
    public int Id { get; set; }
    public string Название { get; set; }
    public string Тренер { get; set; }
    public int Очки { get; set; }
    public int Место { get; set; }

    public FootballTeam(int id, string name, string coach, int score, int place)
    {
        Id = id;
        Название = name;
        Тренер = coach;
        Очки = score;
        Место = place;
    }

    public override string ToString()
    {
        return $"ID={Id}, Название={Название}, Тренер={Тренер}, Очки={Очки}, Место={Место}";
    }
}

class Program
{
    static void Show(string title, List<FootballTeam> list)
    {
        Console.WriteLine(title);
        foreach (var t in list) Console.WriteLine(t);
        Console.WriteLine();
    }

    static void Main()
    {
        var teams = new List<FootballTeam>
        {
            new FootballTeam(1,"Метеор","Иванов",12,10),
            new FootballTeam(2,"Вымпел","Петров",16,7),
            new FootballTeam(3,"Комета","Сидоров",25,1),
            new FootballTeam(4,"Арсенал","Григорьев",22,4),
            new FootballTeam(5,"Буровик","Дорогин",18,6)
        };

        Show("Начальный список", teams);

        var newTeam = new FootballTeam(6, "Звезда", "Тетерин", 14, 9);
        int pos = teams.FindIndex(t => t.Название == "Комета");
        if (pos >= 0) teams.Insert(pos, newTeam);
        Show("После вставки Звезда перед Кометой", teams);

        if (teams.Count >= 2) teams.RemoveAt(1);
        Show("После удаления ID=2", teams);

        var winners = teams.Where(t => t.Очки >= 18).ToList();
        Show("Только команды с очками >= 18", winners);

        var byName = teams.OrderBy(t => t.Название).ToList();
        Show("Сортировка по названию", byName);

        var byPlace = teams.OrderBy(t => t.Место).ToList();
        Show("Сортировка по месту", byPlace);

        Console.ReadKey();
    }
}
