﻿using Calculateur.Backend;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Win32;
using System.IO;

namespace Calculateur.ViewModel
{
    class MainWindow : BindableBase
    {
        private Character character;
        private string fileName;

        public string Name
        {
            get { return character == null ? "No Character" : character.Name; }
        }

        public MainWindow()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            OnPropertyChanged(null);
        }

        public DelegateCommand LoadCharacterCommand
        {
            get { return new DelegateCommand(LoadCharacter); }
        }

        private void LoadCharacter()
        {
            var openFileDialog = new OpenFileDialog { Filter = "Feuille de personnage |*.chr|Tous les fichier |*.*" };
            if (openFileDialog.ShowDialog() == true)
            {
                CharacterManager.Instance.Load(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
            }
        }

        public DelegateCommand SaveCharacterCommand
        {
            get { return new DelegateCommand(SaveCharacter, CanSaveCharacter); }
        }

        private bool CanSaveCharacter()
        {
            return character != null;
        }

        private void SaveCharacter()
        {
            if (fileName == null)
                SaveCharacterAs();
            else
                CharacterManager.Instance.Save(character, fileName);
        }

        public DelegateCommand SaveCharacterAsCommand
        {
            get { return new DelegateCommand(SaveCharacterAs, CanSaveCharacter);}
        }

        private void SaveCharacterAs()
        {
            var saveFileDialog = new SaveFileDialog { Filter = "Feuille de personnage |*.chr|Tous les fichier |*.*" };
            if (saveFileDialog.ShowDialog() == true)
            {
                fileName = saveFileDialog.FileName;
                CharacterManager.Instance.Save(character, fileName);
            }
        }

        public DelegateCommand ExportCharacterCommand
        {
            get { return new DelegateCommand(ExportCharacterAs, CanExportCharacter);}
        }

        private bool CanExportCharacter()
        {
            return character != null;
        }

        private void ExportCharacterAs()
        {
            var saveFileDialog = new SaveFileDialog()
            {
                Filter = "Fichier texte|*.txt|Tous les fichier|*.*",
            };

            if (saveFileDialog.ShowDialog() != true)
                return;
            string fiche = TextExporter.ExportCharacter(character);
            using (var sw = new StreamWriter(saveFileDialog.FileName))
            {
                sw.Write(fiche);
            }
        }
    }
}
