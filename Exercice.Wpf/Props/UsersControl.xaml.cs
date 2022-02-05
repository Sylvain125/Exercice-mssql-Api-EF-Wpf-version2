using AutoMapper;
using Exercice.Dto;
using Exercice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Exercice.Wpf.Props
{
    /// <summary>
    /// Logique d'interaction pour UsersControl.xaml
    /// </summary>
    public partial class UsersControl : UserControl 
    {
        MyClient myClient = new MyClient();

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public UserList Userslist { get; set; } = new UserList();
        public UsersControl()
        {
            InitializeComponent();
            DataContext = Userslist;
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var maRequeteAllOrder = await myClient.GetAllUser();
            var Users = _mapper.Map<IEnumerable<UserModel>>(maRequeteAllOrder);
            Userslist.Users = new ObservableCollection<UserModel>(Users);
        }

        private async void Button_Ajouter(object sender, RoutedEventArgs e)
        {
            var newDto = new UserDto();
            newDto._userFirstName = userFirstName.Text;
            newDto._userLastName = userLastName.Text;
            newDto._emailAddress = emailAddress.Text;
            newDto._address = addresse.Text;
            newDto._companyName = companyName.Text;
            newDto._phone = Phone.Text;
            newDto._imgUrl = AvatarUrl.Text;
            newDto._role = Role.Text;

            try { 
            var maRequeteAllUser = await myClient.PostUser(newDto);
            MessageBox.Show("Ajouté avec succès", "ADD", MessageBoxButton.OK, MessageBoxImage.Information);
            Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme de connection !", "ADD", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Button_Editer(object sender, RoutedEventArgs e)
        {
            var newDto = new UserDto();
            var userid = UserId.Text;
            newDto._userFirstName = userFirstName.Text;
            newDto._userLastName = userLastName.Text;
            newDto._emailAddress = emailAddress.Text;
            newDto._address = addresse.Text;
            newDto._companyName = companyName.Text;
            newDto._phone = Phone.Text;
            newDto._imgUrl = AvatarUrl.Text;
            newDto._role = Role.Text;

            try
            {
                var maRequeteAll = await myClient.UpdateUserById(newDto, userid);
                MessageBox.Show("Edité avec succès", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme de connection !", "ADD", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private async void Button_Supp(object sender, RoutedEventArgs e)
        {
            try
            {
                string idShow = UserId.Text;
                var maRequeteParId = await myClient.DeleteUserById(idShow);
                MessageBox.Show("Supprimé avec succès", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme de connection !", "ADD", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
