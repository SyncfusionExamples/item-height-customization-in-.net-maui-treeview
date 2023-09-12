using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewMaui
{
    public class FileManager : INotifyPropertyChanged
    {
        #region Fields

        private string fileName;
        private ImageSource imageIcon;
        private ObservableCollection<FileManager> subFiles;
        private string fileDescription;
        //"Books for recording periodic entries by the user, such as daily information about a journey, are called logbooks or simply logs. A similar book for writing the owner's daily private personal events, information, and ideas is called a diary or personal journal.";

        #endregion

        #region Constructor
        public FileManager()
        {
        }

        #endregion

        #region Properties
        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisedOnPropertyChanged("SubFiles");
            }
        }

        public string FileDescription
        {
            get { return fileDescription; }
            set
            {
                fileDescription = value;
                RaisedOnPropertyChanged("FileDescription");
            }
        }
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisedOnPropertyChanged("FileName");
            }
        }
        public ImageSource ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
