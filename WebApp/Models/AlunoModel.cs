using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using App.Repository;
using App.Domain;

namespace WebApp.Models
{
    public class AlunoModel
    {


        public List<AlunoDTO> ListarAluno(int? id = null)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                return alunoBD.ListarAlunosDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar aluno: Erro => {ex.Message}");
            }
        }

        public void Inserir(AlunoDTO aluno)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir dados do aluno: Erro => {ex.Message}");
            }
        }

        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar dados do aluno: Erro => {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar dados do aluno: Erro => {ex.Message}");
            }
        }
    }
}