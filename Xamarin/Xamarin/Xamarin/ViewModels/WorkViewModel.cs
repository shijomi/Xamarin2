using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Models;
using Xamarin.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Xamarin.ViewModels
{

    public class WorkViewModel: BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Work> works;
        #endregion
        #region Properties
        public ObservableCollection<Work> Books
        {
            get { return this.works; }
            set { SetValue(ref this.works, value); }
        }
        #endregion
        #region Constructor
        public WorkViewModel()
        {
            this.apiService = new ApiService();
            this.LoadWork();

        }
        #endregion
        #region Method
        private async void LoadWork()
        {
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error en Internet",
                    connection.Message,
                    "Accept"
                    );

                return;
            }
            var response = await apiService.GetList<Work>(
             "http://localhost:53796//",
             "api/",
             "Works"
             );
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Service Work Error",
                    response.Message,
                    "Acept"
                    );
                return;
            }
            MainViewModel mainViewModel = MainViewModel.GetInstance();
            mainViewModel.ListWork = (List<Work>)response.Result;

            this.Books = new ObservableCollection<Work>(this.ToWorkCollect());
        }

        private IEnumerable<Work> ToWorkCollect()
        {
            ObservableCollection<Work> collect = new ObservableCollection<Work>();
            MainViewModel main = MainViewModel.GetInstance();
            foreach (var lista in main.ListWork)
            {
                Work work = new Work();
                work.WorkID = lista.woorkID;
                work.Name = lista.Name;
                work.Email = lista.Email;
                work.Phone = lista.Phone;
                collect.Add(work);

            }
            return (collect);
        }
        #endregion


    }
}