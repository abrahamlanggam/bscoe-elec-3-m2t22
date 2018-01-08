using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hacker : MonoBehaviour {


	int level;
	string theme, ans;
	enum Screen {Name,MainMenu, Password, Win };
	Screen currentScreen = Screen.Name;
	System.Random rnd = new System.Random();
	public string[] easy = new string[6];
	public string[] medium = new string[6];
	public string[] hard = new string[6];

	string name="";

	//Terminal.ClearScreen();

	void Start(){
		
		GetName ();
	}

	void GetName(){
		currentScreen = Screen.Name;
		Terminal.WriteLine ("ENTER YOUR USERNAME");
	}

	void OnUserInput(string input){
		Debug.Log (currentScreen);
		if (input == "menu") {
			DisplayStartMenu ();
		}else if (input == "auqna"){
			Application.Quit ();
		} else if (input == "badank"){
			EasterEgg ();
		}else if (currentScreen == Screen.Name) {
			name = name+=input;
			DisplayStartMenu ();

		} else if (currentScreen == Screen.MainMenu) {
			Selection(input);
		} else if (currentScreen == Screen.Password) {
			if (input == ans) {
				currentScreen = Screen.Win;
				DisplayWinScreen();
			}
			else {
				RunGame();
			}
		} else if (currentScreen == Screen.Win) {
			DisplayStartMenu();
		}
	}


	void EasterEgg(){
		currentScreen = Screen.Name;
		Terminal.ClearScreen ();
		Terminal.WriteLine ("Dalawang beses na yan!! Unang una pinagtanggol kita sa lahat ng tropa ha Kahit takpan mo pa yang mukha mo ha ilalabas ko 'to dahil isa kang gago!! Dito ka pa nakatira sa bahay ko, pinapatira kita, tinuring kitang ka- kaibigan 'tol! Ha? Kahit anong sabihin mo 'tol I don't know what the fuck you did. Sumisigaw yung anak ko sa taas \" Daddy daddy daddy\" Sabi ko \"Anak baket?\" Ha? \"Si tito Badang hindi ko alam nakatayo na lang jan hawak hawak yung kamay ko\" GAGO KA BA?? Sisirain kita ngayon, yang pangalan mo? PUTANG INA MO!!! Nagpunas si badang ng sugat. LUMAYAS KA!!! TANGINA MO! ‌Motherfucker, \" 'tol Hinawakan ko lang ang kamay niya.\" Gago ka ba? bakit mo papasukin ang kwarto ng anak ko't hahawakan mo ang kamay isa kang timang! Inexpose ang braso sa camera may kaso ka pa 'tol kakasuhan kita sirang sira ka sakin gago ka!! Pinagtanggol kita sa lahat ng tao sa ginawa mo ha, pangalawang beses na yan 'tol. Unang una sa pamangkin ko. Ha? Unanguna ngayon anak ko gago may anak kang babae! Gago! Bakit mo papasukin at hawakan kamay STUPID! sirang sira ka sakin Badang wala kana sakin, bumwelo Ghaggo!!! May anak ka pang kabae ghaggo!!! Kumahol yung aso Dang lumabas ka tangina mababaril kita dito lumabas ka!! Sstupid muthafucker sasabihing lasing gago!");
	}

	void DisplayStartMenu (){
		 currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine ("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n░░░░░░░░░░░░░▄▄▄▄▄▄▄░░░░░░░░░\n░░░░░░░░░▄▀▀▀░░░░░░░▀▄░░░░░░░\n░░░░░░░▄▀░░░░░░░░░░░░▀▄░░░░░░\n░░░░░░▄▀░░░░░░░░░░▄▀▀▄▀▄░░░░░\n░░░░▄▀░░░░░░░░░░▄▀░░██▄▀▄░░░░\n░░░▄▀░░▄▀▀▀▄░░░░█░░░▀▀░█▀▄░░░\n░░░█░░█▄▄░░░█░░░▀▄░░░░░▐░█░░░\n░░▐▌░░█▀▀░░▄▀░░░░░▀▄▄▄▄▀░░█░░\n░░▐▌░░█░░░▄▀░░░░░░░░░░░░░░█░░\n░░▐▌░░░▀▀▀░░░░░░░░░░░░░░░░▐▌░\n░░▐▌░░░░░░░░░░░░░░░▄░░░░░░▐▌░\n░░▐▌░░░░░░░░░▄░░░░░█░░░░░░▐▌░\n░░░█░░░░░░░░░▀█▄░░▄█░░░░░░▐▌░\n░░░▐▌░░░░░░░░░░▀▀▀▀░░░░░░░▐▌░\n░░░░█░░░░░░░░░░░░░░░░░░░░░█░░\n░░░░▐▌▀▄░░░░░░░░░░░░░░░░░▐▌░░\n░░░░░█░░▀░░░░░░░░░░░░░░░░▀░░░\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
		Terminal.WriteLine ("HELLO "+ name.ToUpper() +"!\nWELCOME BACK!");
		Terminal.WriteLine ("ENTER 1 TO PLAY "+ easy[0] + " CATEGORY");
		Terminal.WriteLine ("ENTER 2 TO PLAY "+ medium[0] + " CATEGORY");
		Terminal.WriteLine ("ENTER 3 TO PLAY "+ hard[0] + " CATEGORY");

	}
		
	void Selection(string input){
		if (input == "1") {
			level = 1;
			theme = easy[0];
			Debug.Log ("Easy Category");
			RunGame();
		}
		else if (input == "2") {
			level = 2;
			theme = medium[0];
			Debug.Log ("Medium Category");
			RunGame();
		}
		else if (input == "3") {
			level = 3;
			theme = hard[0];
			Debug.Log ("Hard Category");
			RunGame();
		}
		else {
			Terminal.WriteLine("PLEASE CHOOSE FROM THE SELECTION");
		}
	
	}

	void RunGame(){
		currentScreen = Screen.Password;
		Debug.Log ("game started");
		Terminal.ClearScreen();
		Terminal.WriteLine("Level " + level + " - " + theme);
		string pass = Randomizer(Random.Range(1, 6));
		Terminal.WriteLine("Enter password: " + pass);
	}


	string Randomizer(int rand){
		string pass = "";

		if (level == 1) {
			pass = easy[rand];
		} else if (level == 2) {
			pass = medium[rand];
		} else if (level == 3) {
			pass = hard[rand];
		}
		ans = pass;

		string output = "";
		int arraysize = pass.Length;
		int[] randomArray = new int[arraysize];

		for (int i = 1; i < arraysize; i++)
		{
			randomArray[i] = i;
		}

		arraysize = randomArray.Length;
		int random;
		int temp;

		for (int i = 1; i < arraysize; i++)
		{
			random = 0 + (int)(rnd.NextDouble() * (arraysize - i));
	
			temp = randomArray[random];
			randomArray[random] = randomArray[i];
			randomArray[i] = temp;
		}

		for (int i = 0; i < arraysize; i++)
		{
			output += pass[randomArray[i]];
		}

		pass = output;
		return pass;
	}



	void DisplayWinScreen (){
		Terminal.WriteLine("\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n░░░░░░░▄▄▀▀▀▀▀▀▀▀▀▀▄▄█▄░░░░▄░░░░█░░░░░░░\n░░░░░░█▀░░░░░░░░░░░░░▀▀█▄░░░▀░░░░░░░░░▄░\n░░░░▄▀░░░░░░░░░░░░░░░░░▀██░░░▄▀▀▀▄▄░░▀░░\n░░▄█▀▄█▀▀▀▀▄░░░░░░▄▀▀█▄░▀█▄░░█▄░░░▀█░░░░\n░▄█░▄▀░░▄▄▄░█░░░▄▀▄█▄░▀█░░█▄░░▀█░░░░█░░░\n▄█░░█░░░▀▀▀░█░░▄█░▀▀▀░░█░░░█▄░░█░░░░█░░░\n██░░░▀▄░░░▄█▀░░░▀▄▄▄▄▄█▀░░░▀█░░█▄░░░█░░░\n██░░░░░▀▀▀░░░░░░░░░░░░░░░░░░█░▄█░░░░█░░░\n██░░░░░░░░░░░░░░░░░░░░░█░░░░██▀░░░░█▄░░░\n██░░░░░░░░░░░░░░░░░░░░░█░░░░█░░░░░░░▀▀█▄\n██░░░░░░░░░░░░░░░░░░░░█░░░░░█░░░░░░░▄▄██\n░██░░░░░░░░░░░░░░░░░░▄▀░░░░░█░░░░░░░▀▀█▄\n░▀█░░░░░░█░░░░░░░░░▄█▀░░░░░░█░░░░░░░▄▄██\n░▄██▄░░░░░▀▀▀▄▄▄▄▀▀░░░░░░░░░█░░░░░░░▀▀█▄\n░░▀▀▀▀░░░░░░░░░░░░░░░░░░░░░░█▄▄▄▄▄▄▄▄▄██\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
		Terminal.WriteLine ("  GGGG   OOOOO   OOOOO  DDDDD       JJJ  OOOOO  BBBBB   \n GG  GG OO   OO OO   OO DD  DD      JJJ OO   OO BB   B  \nGG      OO   OO OO   OO DD   DD     JJJ OO   OO BBBBBB  \nGG   GG OO   OO OO   OO DD   DD JJ  JJJ OO   OO BB   BB \n GGGGGG  OOOO0   OOOO0  DDDDDD   JJJJJ   OOOO0  BBBBBB  \n                                                        ");
	}

	string Shuffle(string s)
	{
		string output = "";
		int arraysize = s.Length;
		int[] randomArray = new int[arraysize];

		for (int i = 1; i < arraysize; i++)
		{
			randomArray[i] = i;
		}



		for (int i = 1; i < arraysize; i++)
		{
			output += s[randomArray[i]];
		}

		return output;
	}
}
