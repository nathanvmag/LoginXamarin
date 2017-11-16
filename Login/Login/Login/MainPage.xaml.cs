using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
namespace Login
{
   
    public partial class MainPage : ContentPage
	{

        public MainPage()
        {
            InitializeComponent();
            WebClient webclient = new WebClient();
            StackLayout st1 = new StackLayout();
            st1.HorizontalOptions = LayoutOptions.FillAndExpand;

            Label lb1 = new Label();
            lb1.Text = "VOCÊ ESTA REGISTRANDO";
            lb1.FontSize *= 1.6f;
            lb1.HorizontalOptions = LayoutOptions.Center;
            st1.Children.Add(lb1);
            for (int i = 0; i < 5; i++)

            {
                Label lb2 = new Label();
                lb2.Text = "";
                lb2.FontSize *= 1f;
                lb2.HorizontalOptions = LayoutOptions.Center;
                st1.Children.Add(lb2);
            }

            Entry email1 = new Entry();
            email1.Placeholder = "Digite email";
            email1.Keyboard = Keyboard.Email;
            email1.HorizontalOptions = LayoutOptions.FillAndExpand;
            st1.Children.Add(email1);
            Entry pass1 = new Entry();
            pass1.Placeholder = "Digite a senha";
            pass1.IsPassword = true;
            pass1.HorizontalOptions = LayoutOptions.FillAndExpand;
            st1.Children.Add(pass1);
            Button confirm1 = new Button();
            confirm1.Text = "Registrar";
            confirm1.VerticalOptions = LayoutOptions.Center;
            confirm1.HorizontalOptions = LayoutOptions.Center;
            st1.Children.Add(confirm1);
            confirm1.Clicked += delegate
            {
                if (email1.Text != "" && pass1.Text != "") {
                    try
                    {
                        string result = webclient.DownloadString("https://godsofnave.000webhostapp.com/login.php?serv=2&email=" + email1.Text + "&pass=" + pass1.Text);
                        if (result == "ok")
                        {
                            DisplayAlert("Sucesso", "Registrado com sucesso", "OK");
                        }
                    }
                    catch
                    {
                        DisplayAlert("Erro", "Problemas de conexão", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Falha", "Preencha todos campos", "OK");
                } 
            };
            Button register1 = new Button();
            register1.Text = "Logar";
            register1.VerticalOptions = LayoutOptions.Center;
            register1.HorizontalOptions = LayoutOptions.Center;
            st1.Children.Add(register1);
            StackLayout st = new StackLayout();
            st.HorizontalOptions = LayoutOptions.FillAndExpand;
            register1.Clicked += delegate
            {
                this.Content = st;
            };



            
            this.Content = st;
            Label lb = new Label();
            lb.Text = "VOCÊ ESTA LOGANDO";
            lb.FontSize *= 1.6f;
            lb.HorizontalOptions = LayoutOptions.Center;
            st.Children.Add(lb);
            for (int i = 0; i < 5; i++)

            {
                Label lb3 = new Label();
                lb3.Text = "";
                lb3.FontSize *= 1f;
                lb3.HorizontalOptions = LayoutOptions.Center;
                st.Children.Add(lb3);
            }
               
            Entry email = new Entry();
            email.Placeholder = "Digite email";
            email.Keyboard = Keyboard.Email;
            email.HorizontalOptions = LayoutOptions.FillAndExpand;
            st.Children.Add(email);
            Entry pass = new Entry();
            pass.Placeholder = "Digite a senha";
            pass.IsPassword = true;
            pass.HorizontalOptions = LayoutOptions.FillAndExpand;
            st.Children.Add(pass);
            Button confirm = new Button();
            confirm.Text = "Logar";
            confirm.VerticalOptions = LayoutOptions.Center;
            confirm.HorizontalOptions = LayoutOptions.Center;
            confirm.Clicked += delegate
            {
                if (email.Text != "" && pass.Text != "")
                {

                    try
                    {
                        string result = webclient.DownloadString("https://godsofnave.000webhostapp.com/login.php?serv=1&email=" + email.Text + "&pass=" + pass.Text);
                        if (result == "ok")
                        {
                            DisplayAlert("Sucesso", "Logado com sucesso", "OK");
                        }
                        else
                        {
                            DisplayAlert("Erro", "Senha incorreta", "OK");
                        }
                    }
                    catch
                    {
                        DisplayAlert("Erro", "Problemas de conexão", "OK");
                    }
                   
                }
                else
                {
                    DisplayAlert("Falha", "Preencha todos campos", "OK");
                }

               
            };
            st.Children.Add(confirm);
            Button register = new Button();
            register.Text = "Registrar";
            register.VerticalOptions = LayoutOptions.Center;
            register.HorizontalOptions = LayoutOptions.Center;
            st.Children.Add(register);
            register.Clicked += delegate
             {
                 this.Content = st1;
             };
        }
	}
}
