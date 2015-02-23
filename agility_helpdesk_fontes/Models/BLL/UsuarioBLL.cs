using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.Security;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Security.Cryptography;

using BO;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        #region Objetos

        //Objetos usados na para criptografar senha
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();

        //Chave para criptografia
        String Chave = "AgilityWD";

        UsuarioDAL usuarioDAL;

        #endregion

        #region Métodos

        public Usuario GetUsuarioPorSenha(string email, string senha)
        {
            Usuario usuario = new Usuario();
            
            if (email != "" || senha != "")
            {
                usuarioDAL = new UsuarioDAL();
                usuario = usuarioDAL.AutenticarUsuarioPorSenha(email, senha);
            }

            return usuario;
        }

        public Usuario GetUsuarioAdminPorSenha(string email, string senha)
        {
            Usuario usuario = new Usuario();

            if (email != "" || senha != "")
            {    
                usuarioDAL = new UsuarioDAL();
                usuario = usuarioDAL.AutenticaUsuarioAdminPorSenha(email, senha);
            }
            
            return usuario;
        }

        public Usuario GetUsuarioPorEmail(string emailUsuario)
        {
            Usuario usuario = new Usuario();
            usuarioDAL = new UsuarioDAL();

            //Chama BLL para validar se e-mail fornecido existe na base
            usuario = usuarioDAL.RecuperaSenhaPorEmail(emailUsuario);

            //Caso e-mail exista gera nova senha
            if (usuario.Email != "")
            {
                usuario = GeraNovaSenha(usuario);
            }

            return usuario;
        }

        public Usuario GeraNovaSenha(Usuario user)
        {
            //Gera Número aleatório para senha
            int numAleatorio = 0;
            Random randon = new Random();
            numAleatorio = randon.Next(10, 10000);

            Usuario usuario = user;
            usuario.Senha = Convert.ToString(numAleatorio);
            //Converte Número aleatório String para fazer criptografia de senha
            string novaSenha = CriptografarSenha(Convert.ToString(numAleatorio));

            //Salva nova senha criptografada
            usuarioDAL.AtualizaSenhaUsuario(usuario.IdUsuario, novaSenha);

            return usuario;

        }

        public Usuario InsereUsuario(Usuario usuarioBLL)
        {
            usuarioDAL = new UsuarioDAL();

            if (usuarioBLL != null)
            {
                usuarioBLL.Senha = CriptografarSenha(usuarioBLL.Senha);
                usuarioBLL = usuarioDAL.InsereNovoUsuario(usuarioBLL);
            }

            return usuarioBLL;
        }

        public DataTable GetUsuarios(int idEmpresaBLL, int idUsuarioBLL)
        {
            DataTable dt = new DataTable();
            usuarioDAL = new UsuarioDAL();
            dt = usuarioDAL.GetUsuarios(idEmpresaBLL, idUsuarioBLL);
            return dt;
        }

        public void AutalizaSenhaUsuario(Usuario usuario, string novaSenha)
        {
            if (usuario.IdUsuario != 0 || usuario.Ativo != false)
            {
                usuarioDAL = new UsuarioDAL();
                usuarioDAL.AtualizaSenhaUsuario(usuario.IdUsuario, novaSenha);
            }
        }

        public void AtualizaUsuarioPorId(Usuario usuarioBLL)
        {
            if (usuarioBLL.IdUsuario != 0)
            {
                usuarioDAL = new UsuarioDAL();
                usuarioBLL.Senha = CriptografarSenha(usuarioBLL.Senha);
                usuarioDAL.AtualizaUsuarioPorId(usuarioBLL);
            }
        }

        public void DeleteUserById(int idUsuario)
        {
            if (idUsuario != 0)
            {
                usuarioDAL = new UsuarioDAL();
                usuarioDAL.DeletaUsuarioPorId(idUsuario);
            }
        }

        public Boolean ValidaEmail(string email)
        {
            Boolean Ok = false;
            usuarioDAL = new UsuarioDAL();

            if (email != "")
            {
                Ok = usuarioDAL.ValidaEmail(email);
            }

            return Ok;
        }

        public DataTable ListaUsuarioPorId(int idUsuario)
        {
            DataTable dt = new DataTable();
            
            if (idUsuario != 0)
            {
                usuarioDAL = new UsuarioDAL();
                dt = usuarioDAL.GetUsuarioPorId(idUsuario);    
            }

            return dt;
        }

        public String CriptografarSenha(string senha)
        {
            des.Key = md5Crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Chave));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            var buff = ASCIIEncoding.ASCII.GetBytes(senha);
            senha = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

            return senha;
        }

        #endregion
    }
}
