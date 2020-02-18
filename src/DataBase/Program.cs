using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Table
{
    static void Main()
    {
        string cs = @"URI=file:C:\sqlite\test.db";

        using var con = new SQLiteConnection(cs);
        con.Open();

        using var cmd = new SQLiteCommand(con);

        cmd.CommandText = "DROP TABLE IF EXISTS patient";
        cmd.ExecuteNonQuery();

        cmd.CommandText = @"CREATE TABLE patient(pat_id INTEGER PRIMARY KEY, fname TEXT, lname TEXT)";
        cmd.ExecuteNonQuery();

        cmd.CommandText = "INSERT INTO patient(pat_id,fname,lname) VALUES(1, 'Mike', 'O Hara')";
        cmd.ExecuteNonQuery();

        cmd.CommandText = "INSERT INTO patient(pat_id, fname, lname) VALUES(2, 'Matthew', 'Nolan')";
        cmd.ExecuteNonQuery();

        Console.WriteLine("Table Patient was created");

        string stm = "SELECT * FROM patient LIMIT 5";

        using var cmd1 = new SQLiteCommand(stm, con);
        using SQLiteDataReader rdr = cmd1.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)}");
        }
    }



}
