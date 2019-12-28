using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Models;

namespace Xamarin.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Work> Listwork { get; set; }
        #endregion

        #region ViewModel
        public WorkViewModel workViewModel { get; set; }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public List<Work> ListWork { get; internal set; }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.workViewModel = new WorkViewModel();

        }


    }
}
