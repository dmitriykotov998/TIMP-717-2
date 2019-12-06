using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Net;


public class GameManager : MonoBehaviour 
{
	public static GameManager Instance { set; get;}


	public GameObject mainMenu;
	public GameObject serverMenu;
	public GameObject connectMenu;
    public GameObject avtorMenu;

	public GameObject serverPrefab;
	public GameObject clientPrefab;

	public InputField nameInput;

	private void Start()
	{
		
		Instance = this;
		serverMenu.SetActive (false);
		connectMenu.SetActive (false);
        avtorMenu.SetActive(false);
        DontDestroyOnLoad (gameObject);

	}

	public void ConnectButton()
	{
		mainMenu.SetActive (false);
		connectMenu.SetActive(true);

	}
		

	public void HostButton()
	{
		try
		{
            //создание хоста
			Server s = Instantiate(serverPrefab).GetComponent<Server>();
			s.Init();

			Client c = Instantiate(clientPrefab).GetComponent<Client>();
			c.clientName = nameInput.text;
			c.isHost = true;

			if (c.clientName == "")
				c.clientName = "Host";
			c.ConnectToServer("192.168.2.8",24);

		}

		catch (Exception e)
		{
			Debug.Log (e.Message);
		}

		mainMenu.SetActive (false);
		serverMenu.SetActive (true);
	}

	public void ConnectToServerButton()
	{
        //подключение клиента к игре
		string hostAddress = GameObject.Find ("HostInput").GetComponent<InputField> ().text;
		if (hostAddress == "")
			hostAddress = "192.168.2.8";
		try
		{
			Client c = Instantiate(clientPrefab).GetComponent<Client>();
			c.clientName = nameInput.text;
			if (c.clientName == "")
				c.clientName = "Client";
			c.ConnectToServer(hostAddress,24);
			connectMenu.SetActive(false);
		}

		catch(Exception e) 
		{
			Debug.Log (e.Message);
		}
	}
    
	public void BackButton()
	{
        //выход в меню
		mainMenu.SetActive (true);
		serverMenu.SetActive (false);
		connectMenu.SetActive (false);
        avtorMenu.SetActive(false);

        Server s = FindObjectOfType<Server> ();
		if (s != null)
			Destroy (s.gameObject);

		Client c = FindObjectOfType<Client> ();
		if (c != null)
			Destroy (c.gameObject);
	}


	public void StartGame()
	{
        //загрузка игры
		SceneManager.LoadScene ("Game");
	}

    public void ExitButton()
    {
        Application.Quit();
    }

    public void AvtorButton()
    {
        mainMenu.SetActive(false);
        avtorMenu.SetActive(true);
    }

    public void Backkb()
    {
        avtorMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameManager g = FindObjectOfType<GameManager>();
        if (g != null)
            Destroy(g.gameObject);

    }



}
