﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneration_Kurlishuk.Models;
using ReportGeneration_Kurlishuk.Classes.Common;
using MySql.Data.MySqlClient;

namespace ReportGeneration_Kurlishuk.Classes
{
    public class DisciplineContext : Discipline
    {
        public DisciplineContext(int Id, string Name, int IdGroup) : base(Id, Name, IdGroup) { }
        public static List<DisciplineContext> AllDisciplines()
        {
            List<DisciplineContext> allDisciplines = new List<DisciplineContext>();
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader BDDisciplines = Connection.Query("SELECT * FROM discipline ORDER BY Name;", connection);
            while (BDDisciplines.Read())
            {
                allDisciplines.Add(new DisciplineContext(
                    BDDisciplines.GetInt32(0),
                    BDDisciplines.GetString(1),
                    BDDisciplines.GetInt32(2)));
            }
            Connection.CloseConnection(connection);
            return allDisciplines;
            
               
            

        }
        
    }
}
