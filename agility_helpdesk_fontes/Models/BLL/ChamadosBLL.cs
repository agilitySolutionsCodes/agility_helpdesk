using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

using BO;
using DAL;

namespace BLL
{
    public class ChamadosBLL
    {
        #region Objetos

        ChamadosDAL chamadoDAL;

        #endregion

        #region Métodos

        public DataTable GetChamados(Usuario usuarioBLL)
        {
            DataTable dt = new DataTable();
            chamadoDAL = new ChamadosDAL();
            dt = chamadoDAL.ListaChamados(usuarioBLL);
            return dt;
        }

        public DataTable GetNumeroChamados(int idEmpresaBLL, string statusFiltro)
        {
            DataTable dt = new DataTable();

            chamadoDAL = new ChamadosDAL();
            dt = chamadoDAL.GetNumeroChamadosFinalizados(idEmpresaBLL, statusFiltro);

            return dt;
        }

        public DataTable GetChamadosPorPalavra(string palavraChave)
        {
            DataTable dt = new DataTable();

            if (palavraChave != "")
            {
                chamadoDAL = new ChamadosDAL();
                dt = chamadoDAL.BuscaChamadoPorPalavraChave(palavraChave);
            }

            return dt;
        }

        public DataTable ListaChamadosPorId(int idUsuario)
        {
            DataTable dt = new DataTable();

            if (idUsuario != 0)
            {
                chamadoDAL = new ChamadosDAL();
                dt = chamadoDAL.ListaChamadosPorId(idUsuario);
            }

            return dt;
        }

        public DataTable ListaDetalheChamados(int idChamado)
        {
            DataTable dt = new DataTable();

            if (idChamado != 0)
            {
                chamadoDAL = new ChamadosDAL();
                dt = chamadoDAL.ListaDetalheChamado(idChamado);
            }

            return dt;
        }

        public Chamado AtenderChamado(int idUsuario, int idChamado)
        {
            Chamado chamado = new Chamado();
            chamado.IdChamado = idChamado;
            chamado.Solicitante = idUsuario;

            if (chamado.IdChamado != 0)
            {
                chamadoDAL = new ChamadosDAL();
                chamadoDAL.AtenderChamado(idUsuario, idChamado);
            }

            return chamado;
        }

        public Chamado FinalizarChamadoAprovar(int idUsuario, int idChamado, string observacao)
        {
            Chamado chamado = new Chamado();

            chamado.IdChamado = idChamado;
            chamado.Observacao = observacao;

            if (chamado.IdChamado != 0)
            {
                chamadoDAL = new ChamadosDAL();
                chamado = chamadoDAL.FinalizarChamadoAprovacao(idUsuario, chamado.IdChamado, chamado.Observacao);
            }

            return chamado;
        }

        public Chamado FinalizarChamado(int idUsuario, int idChamado)
        {
            Chamado chamado = new Chamado();
            chamado.IdChamado = idChamado;

            if (chamado.IdChamado != 0)
            {
                chamado = chamadoDAL.FinalizarChamado(idUsuario, chamado.IdChamado);
            }

            return chamado;
        }

        public Chamado InserirChamado(Chamado chamadoBLL)
        {
            if (chamadoBLL != null)
            {
                chamadoDAL = new ChamadosDAL();
                chamadoBLL = chamadoDAL.InsereNovoChamado(chamadoBLL);
            }

            return chamadoBLL;
        }

        #endregion
    }
}
