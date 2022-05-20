using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTotalCommander.Model;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;

namespace MiniTotalCommander.ViewModel
{
     class ViewModelBrain : BaseViewModel
    {
        private ICommand copy;
        public PanelViewModel LeftPanel { get; set; }
        public PanelViewModel RightPanel { get; set; }

        public ViewModelBrain()
        {
            LeftPanel = new PanelViewModel();
            LeftPanel.CurrentPath = null;
            RightPanel = new PanelViewModel();
            RightPanel.CurrentPath = null;
        }

        public ICommand Copy => copy ?? (copy = new RelayCommand(
            o =>
            {
                //prawy panel akrtywny
                if (LeftPanel.CurrentFile == null)
                {
                    string file = RightPanel.CurrentPath + RightPanel.CurrentFile;
                    string destination = LeftPanel.CurrentPath + RightPanel.CurrentFile;
                    try
                    {
                        Copying.copyFile(file, destination);
                    }
                    catch (IOException)
                    {
                        RightPanel.ErrorDescription = "Taki plik już istnieje";
                    }
                    LeftPanel.CurrentPath = LeftPanel.CurrentPath;
                }
                else
                {
                    string file = LeftPanel.CurrentPath + LeftPanel.CurrentFile;
                    string destination = RightPanel.CurrentPath + LeftPanel.CurrentFile;
                    try
                    {
                        Copying.copyFile(file, destination);
                        
                    }
                    catch (IOException)
                    {
                        RightPanel.ErrorDescription = "Taki plik już istnieje";
                    }
                    RightPanel.CurrentPath = RightPanel.CurrentPath;

                }
            },
            o => LeftPanel.CurrentFile != null && RightPanel.CurrentPath != null || RightPanel.CurrentFile != null && LeftPanel.CurrentPath != null
            ));
    }
}
