using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Common_Library.Models;
using Common_Library.Models.Servidor;
using System.Xml.Serialization;
using Common_Library.Models.GameModels;

namespace Common_Library.Controllers
{
    public class Server
    {
        public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        /// <summary>
        /// Esta função efetua o registo dos utilizadores no servidor
        /// </summary>
        /// <param name="_nomeAbreviado">Nome Real do Utilizador</param>
        /// <param name="_username">Nome do Utilizador</param>
        /// <param name="_password">Password do Utilizador</param>
        /// <param name="_email">Email do Utilizador</param>
        /// <param name="_fotografia">Fotografia do Utilizador em Base64</param>
        /// <param name="_pais">Pais do Utilizador</param>
        /// <returns>Retorna o id do utilizador</returns>
        public string registar(string _nomeAbreviado, string _username, string _password, string _email, string _fotografia, string _pais)
        {
            XDocument xmlPedido = null;
            string mensagem = string.Empty;
            byte[] data = null;
            Stream newStream = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            string resultado = string.Empty;
            Stream receiveStream = null;
            XDocument xmlResposta = null;
            string id = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/registo");
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            xmlPedido = XDocument.Parse("<registo><nomeabreviado></nomeabreviado><username></username><password></password><email></email><fotografia></fotografia><pais></pais></registo>");
            xmlPedido.Element("registo").Element("nomeabreviado").Value = _nomeAbreviado;
            xmlPedido.Element("registo").Element("username").Value = _username;
            xmlPedido.Element("registo").Element("password").Value = _password;
            xmlPedido.Element("registo").Element("email").Value = _email;
            xmlPedido.Element("registo").Element("fotografia").Value = _fotografia;
            xmlPedido.Element("registo").Element("pais").Value = _pais;

            mensagem = xmlPedido.Root.ToString();
            data = Encoding.Default.GetBytes(mensagem);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;
            newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            response = (HttpWebResponse)request.GetResponse();//enviar o meu xmlpedido para o servidor
            receiveStream = response.GetResponseStream();
            streamReader = new StreamReader(receiveStream, Encoding.UTF8);
            resultado = streamReader.ReadToEnd();
            response.Close();
            streamReader.Close();
            xmlResposta = XDocument.Parse(resultado);

            if (xmlResposta.Element("resultado").Element("status").Value == "ERRO")
            {
                id = string.Empty;
            }
            else
            {
                id = xmlResposta.Element("resultado").Element("objeto").Value;
            }
            return id;
        }
        /// <summary>
        /// Esta função faz o login do Utilizador
        /// </summary>
        /// <param name="_username">Nome de Utilizador</param>
        /// <param name="_password">Password de Utilizador</param>
        /// <returns>O id do Utilizador</returns>
        public string login(string _username, string _password)
        {
            XDocument xmlPedido = null;
            string mensagem = string.Empty;
            byte[] data = null;
            Stream newStream = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            string resultado = string.Empty;
            Stream receiveStream = null;
            XDocument xmlResposta = null;
            string id = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/autentica");
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            xmlPedido = XDocument.Parse("<credenciais><username></username><password></password></credenciais>");
            xmlPedido.Element("credenciais").Element("username").Value = _username;
            xmlPedido.Element("credenciais").Element("password").Value = _password;

            mensagem = xmlPedido.Root.ToString();
            data = Encoding.Default.GetBytes(mensagem);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;
            newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            response = (HttpWebResponse)request.GetResponse();

            receiveStream = response.GetResponseStream();
            streamReader = new StreamReader(receiveStream, Encoding.UTF8);
            resultado = streamReader.ReadToEnd();
            response.Close();
            streamReader.Close();
            xmlResposta = XDocument.Parse(resultado);
            if(xmlResposta.Element("resultado").Element("status").Value == "ERRO")
            {
                return string.Empty;
            }
            else
            {
                return xmlResposta.Element("resultado").Element("objeto").Element("ID").Value;
            }
        }
        /// <summary>
        /// Regista o Resultado de um Jogo
        /// </summary>
        /// <param name="_nivel">Nivel do Jogo</param>
        /// <param name="_tempo">Tempo de Jogo</param>
        /// <param name="_vitoria">Se Jogo foi ganho</param>
        /// <param name="_id">ID do Utilizador</param>
        /// <returns></returns>
        public string registoJogo(TipoDeJogo _nivel, TimeSpan _tempo, bool _vitoria, string _id)
        {
            XDocument xmlPedido = null;
            string mensagem = string.Empty;
            byte[] data = null;
            Stream newStream = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            string resultado = string.Empty;
            Stream receiveStream = null;
            XDocument xmlResposta = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/resultado/" + _id);
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            xmlPedido = XDocument.Parse("<resultado_jogo><nivel></nivel><tempo></tempo><vitoria></vitoria></resultado_jogo>");
            xmlPedido.Element("resultado_jogo").Element("nivel").Value = _nivel.ToString();
            xmlPedido.Element("resultado_jogo").Element("tempo").Value = ((int)_tempo.TotalSeconds).ToString();
            xmlPedido.Element("resultado_jogo").Element("vitoria").Value = _vitoria.ToString();

            mensagem = xmlPedido.Root.ToString();
            data = Encoding.Default.GetBytes(mensagem);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;
            newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            response = (HttpWebResponse)request.GetResponse();

            receiveStream = response.GetResponseStream();
            streamReader = new StreamReader(receiveStream, Encoding.UTF8);
            resultado = streamReader.ReadToEnd();
            response.Close();
            streamReader.Close();
            xmlResposta = XDocument.Parse(resultado);
            return "ok";
        }
        /// <summary>
        /// Obtem o prefil do Utilizador
        /// </summary>
        /// <param name="_username">Nome de Utilizador</param>
        /// <returns>O Prefil do Utilizador</returns>
        public Profile getPerfil(string _username)
        {
            XDocument xperfil = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            string resultado = string.Empty;
            request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/perfil/" + _username);
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            request.Method = "GET";
            request.ContentType = "application/xml";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                resultado = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                xperfil = XDocument.Parse(resultado);
                XElement elem = xperfil.Element("resultado").Element("objeto").Element("perfil");
                XmlSerializer serializer = new XmlSerializer(typeof(Profile));
                Profile profile;
                using (TextReader reader = new StringReader(elem.ToString()))
                {
                    profile = (Profile)serializer.Deserialize(reader);
                }
                return profile;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Obtem a Leaderboard Online
        /// </summary>
        /// <returns></returns>
        public Common_Library.Models.Servidor.Top GetLeaderBoard(ref string status)//status é igual em todo o programa
        {
            XDocument xperfil = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            string resultado = string.Empty;
            request = (HttpWebRequest)WebRequest.Create("https://prateleira.utad.priv:1234/LPDSW/2019-2020/top10");
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            request.Method = "GET";
            request.ContentType = "application/xml";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                resultado = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                xperfil = XDocument.Parse(resultado);
                XElement elem = xperfil.Element("resultado").Element("objeto").Element("top");
                StreamWriter LeaderboardBackup = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Leaderboard.xml"));
                LeaderboardBackup.Write(elem.ToString());
                LeaderboardBackup.Close();
                status = "Online";
                XmlSerializer serializer = new XmlSerializer(typeof(Common_Library.Models.Servidor.Top));
                Common_Library.Models.Servidor.Top Leaderboard;
                using (TextReader reader = new StringReader(elem.ToString()))
                {
                    Leaderboard = (Common_Library.Models.Servidor.Top)serializer.Deserialize(reader);
                }
                return Leaderboard;
            }
            catch (Exception)
            {
                if(File.Exists(Path.Combine(Environment.CurrentDirectory, "Leaderboard.xml")))
                {
                    StreamReader LeaderboardReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "Leaderboard.xml"));
                    string elem = LeaderboardReader.ReadToEnd();
                    LeaderboardReader.Close();
                    status = "Offline";
                    Common_Library.Models.Servidor.Top Leaderboard;
                    XmlSerializer serializer = new XmlSerializer(typeof(Common_Library.Models.Servidor.Top));
                    using (TextReader reader = new StringReader(elem))
                    {
                        Leaderboard = (Common_Library.Models.Servidor.Top)serializer.Deserialize(reader);
                    }
                    return Leaderboard;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Obtem um o campo de jogo
        /// </summary>
        /// <param name="TJ">Tipo de Jogo</param>
        /// <param name="UID">Id do Utilizador</param>
        /// <returns>O Campo de Jogo</returns>
        public Campo GetCampo(TipoDeJogo TJ, string UID)
        {
            XDocument xperfil = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            string resultado = string.Empty;
            request = (HttpWebRequest)WebRequest.Create($"https://prateleira.utad.priv:1234/LPDSW/2019-2020/novo/{TJ.ToString()}/{UID}");
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            request.Method = "GET";
            request.ContentType = "application/xml";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                resultado = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                xperfil = XDocument.Parse(resultado);
                XElement elem = xperfil.Element("resultado").Element("objeto").Element("campo");
                XmlSerializer serializer = new XmlSerializer(typeof(Campo));
                Campo Campo;
                using (TextReader reader = new StringReader(elem.ToString()))
                {
                    Campo = (Campo)serializer.Deserialize(reader);
                }
                return Campo;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
