using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;
namespace Login
{
   
    public partial class MainPage : ContentPage
	{
        ////////////////////RICKÃO COLOCOU AQUI/////////////////////////////////
    /*    internal class StateObject
        {
            internal byte[] sBuffer;
            internal Socket sSocket;
            internal StateObject(int size, Socket sock)
            {
                sBuffer = new byte[size];
                sSocket = sock;
            }
        }*/
        ////////////////////RICKÃO COLOCOU AQUI/////////////////////////////////
        public MainPage()
        {
            InitializeComponent();
            WebClient webclient = new WebClient();
            StackLayout st1 = new StackLayout();
            st1.HorizontalOptions = LayoutOptions.FillAndExpand;
            ////////////////////RICKÃO COLOCOU AQUI/////////////////////////////////

            /*IPAddress ipAddress =
            Dns.Resolve(Dns.GetHostName()).AddressList[0];

            IPEndPoint ipEndpoint =
              new IPEndPoint(ipAddress, 1800);

            Socket listenSocket =
              new Socket(AddressFamily.InterNetwork,
                         SocketType.Stream,
                         ProtocolType.Tcp);

            listenSocket.Bind(ipEndpoint);
            listenSocket.Listen(1);
            IAsyncResult asyncAccept = listenSocket.BeginAccept(
              new AsyncCallback(Server.acceptCallback),
              listenSocket);

            // could call listenSocket.EndAccept(asyncAccept) here
            // instead of in the callback method, but since 
            // EndAccept blocks, the behavior would be similar to 
            // calling the synchronous Accept method

            Console.Write("Connection in progress.");
            if (writeDot(asyncAccept) == true)
            {
                // allow time for callbacks to
                // finish before the program ends 
                Thread.Sleep(3000);
            }
            ////////////////////RICKÃO COLOCOU AQUI/////////////////////////////////
            */
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
                        SendInformationToServer(email1 + "|" + pass1);
                       
                    }
                    catch(Exception e)
                    {
                        DisplayAlert("Erro", e.ToString(), "OK");
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
        void SendInformationToServer(string stringToSend)
        { 
            TcpClient client = new TcpClient();
            IPAddress serverAddress = IPAddress.Parse("http://godsofnave.000webhostapp.com/");
            client.Connect(serverAddress, 314);
            NetworkStream stream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(stringToSend);
            stream.Write(bytesToSend, 0, bytesToSend.Length);
            client.Close();
        }
    }
}