using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Mono.Data.Sqlite;


public class Autorisations : MonoBehaviour 
{
	public static Autorisations Instance { set; get; }

    public GameObject Autor;
    public GameObject Error;

	public string password, password_hash, textbox_hash;

	public InputField log;
	public InputField pass;

    

	private void Start()
	{
		Instance = this;
        Error.SetActive(false);
		DontDestroyOnLoad (gameObject);

        // создание и подключение базы данных Sqlite
		SqliteConnection conn = new SqliteConnection("Data Source=account.db; Version = 3;");
		try
		{
			conn.Open();
		}
		catch (SqliteException ex)
		{
			Debug.Log(ex.Message);
		}
		if (conn.State == ConnectionState.Open)
		{
			SqliteCommand cmd = conn.CreateCommand();
			string sql_command = "DROP TABLE IF EXISTS users;"
				+ "CREATE TABLE users("
				+ "id INTEGER PRIMARY KEY AUTOINCREMENT,"
				+ "login TEXT(24), "
				+ "password TEXT(32))";
			cmd.CommandText = sql_command;
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (SqliteException ex)
			{
				Debug.Log(ex.Message);
			}
			Class2 hash = new Class2();
			password = "1234";
			password_hash = hash.Hash(password);
			string str = "insert into users(login,password) values ('dima','" + password_hash + "')";
			cmd.CommandText = str;
			cmd.ExecuteNonQuery();
			password = "kt36475kt";
			password_hash = hash.Hash(password);
			string stb = "insert into users(login,password) values ('tripi','" + password_hash + "')";
			cmd.CommandText = stb;
			cmd.ExecuteNonQuery();
			password = "rd235";
			password_hash = hash.Hash(password);
			string sta = "insert into users(login,password) values ('7172kds','" + password_hash + "')";
			cmd.CommandText = sta;
			cmd.ExecuteNonQuery();
			password = "m65341756";
			password_hash = hash.Hash(password);
			string stc = "insert into users(login,password) values ('Arm23','" + password_hash + "')";
			cmd.CommandText = stc;
			cmd.ExecuteNonQuery();
			password = "tor3245";
			password_hash = hash.Hash(password);
			string stx = "insert into users(login,password) values ('Tor214','" + password_hash + "')";
			cmd.CommandText = stx;
			cmd.ExecuteNonQuery();
			password = "88005553535";
			password_hash = hash.Hash(password);
			string stx1 = "insert into users(login,password) values ('p122','" + password_hash + "')";
			cmd.CommandText = stx1;
			cmd.ExecuteNonQuery();
		}
		conn.Dispose();
	}
		

	public void LoginButton()
	{
        //Проверка на правильность данных
		Class2 hash = new Class2();
		password_hash = hash.Hash(password);
		textbox_hash = hash.Hash(pass.text);
		SqliteConnection conn = new SqliteConnection("Data Source=account.db; Version = 3;");
		SqliteDataAdapter sda = new SqliteDataAdapter("Select Count (*) From users where Login = '" + log.text + "' and Password = '" + textbox_hash + "'", conn);
		DataTable dt = new DataTable();
		sda.Fill(dt);
		if (dt.Rows[0][0].ToString() == "1")
		{
            SceneManager.LoadScene("Menu");
        }
		else
		{
            Error.SetActive(true);
		}
	}



    public void exit()
    {
        Application.Quit();
    }
		
}


class Class2
{
    //метод SHA1
	public string Hash(string input)
	{
		using (SHA1Managed Passwordd = new SHA1Managed ()) 
		{
			var hash = Passwordd.ComputeHash (Encoding.UTF8.GetBytes (input));
			var sb = new StringBuilder (hash.Length * 2);
			foreach (byte b in hash) 
			{
				sb.Append (b.ToString ("x2"));
			}
			return sb.ToString ();
		}
		
	}
}