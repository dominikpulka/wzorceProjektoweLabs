﻿using System;
using System.Collections.Generic;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej klasy
    public class User
    {
        private bool HasAdminPrivilages;
        public User(bool isAdmin)
        {
            HasAdminPrivilages = isAdmin;
        }
        public void MakeAdmin()
        {
            HasAdminPrivilages = true;
        }
        public bool IsAdmin()
        {
            return HasAdminPrivilages;
        }
    }

    // Nie zmieniaj poniższej klasy
    public abstract class Information
    {
        public abstract void DisplayData();
        public abstract void DisplayRestrictedData();
    }

    // Nie zmieniaj poniższej klasy
    public class Database : Information
    {
        private Dictionary<string, double> Map;

        public Database()
        {
            Map = new Dictionary<string, double>();
            Map.Add("Zyzio MacKwacz", 2500.0);
            Map.Add("Scooby Doo", 11.4);
            Map.Add("Adam Mackiewicz", 15607.95);
            Map.Add("Rick Morty", 429.18);
        }
        public override void DisplayData()
        {
            Console.WriteLine("Użytkownicy:");
            foreach (var pair in Map)
            {
                Console.WriteLine($"{pair.Key}");
            }
        }
        public override void DisplayRestrictedData()
        {
            foreach (var pair in Map)
            {
                Console.WriteLine($"{pair.Key} zarabia {pair.Value} zł miesięcznie");
            }
        }
    }

    public class DatabaseGuard : Information
    {
        // TODO

        private Information _database = new Database();
        private User _user;

        public DatabaseGuard(User user)
        {
            _user = user;
        }

        public override void DisplayData()
        {
            _database.DisplayData();
        }

        public override void DisplayRestrictedData()
        {
            if (_user.IsAdmin())
                _database.DisplayRestrictedData();
            else
                Console.WriteLine("Nie masz wystarczających uprawnień");
        }
    }

    // Nie zmieniaj poniższej klasy
    class Program
    {
        static void Main(string[] args)
        {
            var Zbyszek = new User(false);

            var db = new DatabaseGuard(Zbyszek);
            db.DisplayData();
            Console.WriteLine("---------------------------------------------------------");

            db.DisplayRestrictedData();
            Console.WriteLine("---------------------------------------------------------");

            Zbyszek.MakeAdmin();
            db.DisplayRestrictedData();
        }
    }
}