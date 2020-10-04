using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveKeeper {

    private SaveDataBox _saveDataBox;
    private bool _isSaving;
    private readonly string _savePath;

    public SaveKeeper () {
        _savePath = Application.persistentDataPath + "SaveBox.dat";
        LoadDataBox ();
    }

    public int GetLevelKillsCount (int level) {
        if(_saveDataBox.LevelKills.ContainsKey(level)) {
            return _saveDataBox.LevelKills[level];
        } else {
            return 0;
        }
        
    }
    
    public void SetLevelKillsCount (int level, int kills) {
        if(_saveDataBox.LevelKills.ContainsKey(level)) {
            
            _saveDataBox.LevelKills[level] = kills;
        } else {
            _saveDataBox.LevelKills.Add(level, kills);
        }
    }

    public int GetTotalKillsCount () {
        return _saveDataBox.TotalKills;
    }

    public void IncreaseTotalKillCounter(int kills) {
        _saveDataBox.TotalKills +=  kills;
    }

    public bool SaveDataBox () {
        if (_isSaving) {
            Debug.Log ("Saving in progress");
            return false;
        }

        _isSaving = true;
        FileStream file = null;

        try {
            BinaryFormatter formatter = new BinaryFormatter ();
            file = File.Create (_savePath);

            if (_saveDataBox != null) {
                SaveDataBox save = new SaveDataBox ();

                save.TotalKills = _saveDataBox.TotalKills;
                save.LevelKills = _saveDataBox.LevelKills;

                formatter.Serialize (file, save);
            }

        } catch (System.Exception) {
            Debug.LogError ("Error during saving");
        } finally {
            if (file != null) {
                file.Close ();
            }
            _isSaving = false;
            Debug.Log ($"Saved data box, path = {_savePath}");
        }

        return true;
    }

    public bool LoadDataBox () {
        FileStream fileStram = new FileStream(_savePath, FileMode.OpenOrCreate);

        try {
            if(fileStram == null || fileStram.Length == 0) {
                _saveDataBox = new SaveDataBox();
                _saveDataBox.LevelKills = new Dictionary<int, int>();
                Debug.Log ("Created new save file box");
            } else {
                 BinaryFormatter formatter = new BinaryFormatter ();
                _saveDataBox = (SaveDataBox) formatter.Deserialize (fileStram);
                Debug.Log ("Loaded save file box");
            }

        } catch (Exception ex) {
            Debug.LogError ($"Error during Loading = {ex}");
        } finally {
            if (fileStram != null) {
                fileStram.Close ();
            }
        }
        return true;
    }

}