using System.Collections.Generic;
using UnityEngine;

public class GameLanguage : MonoBehaviour
{
	
	public static GameLanguage gl;
	public string currentLanguage = "en";
	
	Dictionary<string, string> langID; 
	
    // Start is called before the first frame update
    void Start()
    {
        gl = this;
		
		if (PlayerPrefs.HasKey("GameLanguage")) {
            currentLanguage = PlayerPrefs.GetString("GameLanguage");
        }
        else
        {
            ResetLanguage();
        }
		
		Debug.Log("Current language: " + currentLanguage);
		
		WordDefine();
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	public void Setlanguage(string langCode)
    {
        PlayerPrefs.SetString("GameLanguage", langCode);
		currentLanguage = langCode;
    }
	
	public void ResetLanguage()
    {
        Setlanguage("en");
    }
	
	public string Say(string text){
		
		switch(currentLanguage){
			case "id" :
				return FindInDict(langID, text);
			default :
				return text;
		}
	}
	
	public string FindInDict(Dictionary<string, string> selectedLang, string text){
		if(selectedLang.ContainsKey(text))
			return selectedLang[text];
		else
			return "Untranslated";
	}
	
	public void WordDefine(){
		
		//Bahasa Indonesia (id)
		langID = new Dictionary<string, string>()
		{
			{"English", "Inggris"},
			{"Some word.", "Sebuah kata."},
			{"Choose color", "Pilih warna"},
			{"Indonesian", "Bahasa Indonesia"},
			{"Reset", "Atur Ulang"},
			{"Reset Language Preference", "Atur Ulang Pengaturan Bahasa"},
			{"Choose Language", "Pilih Bahasa"},
			{"Restart", "Ulangi"},
			{"Resume", "Lanjut"},
			{"Pause", "Jeda"},
			{"Shoot", "Tembak"},
			{"Paused", "Dijeda"},
			{"Game Over", "Kalah"},
			{"Score", "Skor"},
			{"High Score", "Skor Tertinggi"},
			{"Pause/Resume", "Jeda/Lanjut"},
		};
		
	}
		
}
