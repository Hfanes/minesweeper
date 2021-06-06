using Common_Library.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace minesweeper_uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registar : Page
    {
        public string ImageFilePath = string.Empty;
        public Registar()
        {
            this.InitializeComponent();
        }

        private void buttonMenu_Click(object sender, RoutedEventArgs e)
        {
            MainPage Menu = new MainPage();
            this.Frame.Navigate(typeof(MainPage));
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private async void buttonRegistar_Click(object sender, RoutedEventArgs e)
        {
            Server servidor = new Server();
            string imgb64 = "data:image/jpeg;base64,";
            
            Regex verifyemail = new Regex("([a-zA-Z0-9]{1,})@([a-zA-Z0-9]{1,})\\.([a-zA-Z]{1,})");
            if (!string.IsNullOrEmpty(textBoxNome.Text) && !string.IsNullOrEmpty(textBoxUsername.Text) && !string.IsNullOrEmpty(textBoxPassword.Password) && !string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPais.Text))
            {
                if (verifyemail.IsMatch(textBoxEmail.Text))
                {
                    try
                    {
                        //Converter imagem
                        var bitmap = new RenderTargetBitmap();
                        await bitmap.RenderAsync(PictureShowcase);
                        var image = (await bitmap.GetPixelsAsync()).ToArray();
                        var width = (uint)bitmap.PixelWidth;
                        var height = (uint)bitmap.PixelHeight;
                        double dpiX = 96;
                        double dpiY = 96;
                        var encoded = new InMemoryRandomAccessStream();
                        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, encoded);
                        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, width, height, dpiX, dpiY, image);
                        await encoder.FlushAsync();
                        encoded.Seek(0);
                        var bytes = new byte[encoded.Size];
                        await encoded.AsStream().ReadAsync(bytes, 0, bytes.Length);
                        var base64String = Convert.ToBase64String(bytes);
                        imgb64 += base64String;

                        App.mc.UID = servidor.registar(textBoxNome.Text, textBoxUsername.Text, textBoxPassword.Password, textBoxEmail.Text, imgb64, textBoxPais.Text);
                        App.mc.Online = true;
                        App.mc.Username = textBoxUsername.Text;
                        var messbox = new MessageDialog("Registo comcluido com sucesso", "Registo");
                        messbox.Commands.Add(new UICommand("Menu", (comm) => {
                            MainPage Menu = new MainPage();
                            this.Frame.Navigate(typeof(MainPage));
                        }));
                        messbox.CancelCommandIndex = 0;
                        messbox.DefaultCommandIndex = 0;
                        messbox.ShowAsync();
                    }
                    catch (Exception exc)
                    {
                        var messbox = new MessageDialog("Não foi possivel conectar ao servidor\nPor favor tente mais tarde", "Erro de ligação ao servidor");
                        messbox.Commands.Add(new UICommand("Menu", (comm) => {
                            MainPage Menu = new MainPage();
                            this.Frame.Navigate(typeof(MainPage));
                        }));
                        messbox.CancelCommandIndex = 0;
                        messbox.DefaultCommandIndex = 0;
                        messbox.ShowAsync();
                    }
                }
                else
                {
                    var messbox = new MessageDialog("O Email não é valido", "Email");
                    messbox.Commands.Add(new UICommand("Ok", (comm) => {
                        
                    }));
                    messbox.CancelCommandIndex = 0;
                    messbox.DefaultCommandIndex = 0;
                    messbox.ShowAsync();
                }
            }
            else
            {
                var messbox = new MessageDialog("Não é possivel concluir o registo pois existem campos em branco", "Registo");
                messbox.Commands.Add(new UICommand("Ok", (comm) => {

                }));
                messbox.CancelCommandIndex = 0;
                messbox.DefaultCommandIndex = 0;
                messbox.ShowAsync();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                using (var imageStream = await file.OpenReadAsync())
                {
                    var image = new BitmapImage();
                    //image.DecodePixelWidth = 100;
                    await image.SetSourceAsync(imageStream);
                    PictureShowcase.Source = image;
                }
            }
            else
            {
                ImageFilePath = "";
                PictureShowcase.Source = null;
            }
        }
    }
}
