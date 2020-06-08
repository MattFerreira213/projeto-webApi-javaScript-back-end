using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Repository
{
    public class AlunoDAO
    {
        private string stringconexao = ConfigurationManager.AppSettings["ConnectionString"];
        private IDbConnection conexao;

        public AlunoDAO()
        {
            conexao = new SqlConnection(stringconexao);
            conexao.Open();
        }

        public List<AlunoDTO> ListarAlunosDB(int? id)
        {

            var listaAlunos = new List<AlunoDTO>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                if (id == null)
                    selectCmd.CommandText = "SELECT * FROM Alunos";
                else
                    selectCmd.CommandText = $"SELECT * FROM ALunos WHERE id = {id}";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var alu = new AlunoDTO
                    {
                        id = Convert.ToInt32(resultado["Id"]),
                        nome = Convert.ToString(resultado["nome"]),
                        sobrenome = Convert.ToString(resultado["sobrenome"]),
                        telefone = Convert.ToString(resultado["telefone"]),
                        ra = Convert.ToInt32(resultado["ra"]),
                    };

                    listaAlunos.Add(alu);
                }
                return listaAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public void InserirAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand insertCdm = conexao.CreateCommand();
                insertCdm.CommandText = "INSERT INTO Alunos(nome, sobrenome, telefone, ra) VALUES (@nome, @sobrenome, @telefone, @ra)";

                IDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                IDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                IDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                IDataParameter paramRa = new SqlParameter("ra", aluno.ra);

                insertCdm.Parameters.Add(paramNome);
                insertCdm.Parameters.Add(paramSobrenome);
                insertCdm.Parameters.Add(paramTelefone);
                insertCdm.Parameters.Add(paramRa);

                insertCdm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void AtualizarAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Alunos SET nome=@nome, sobrenome=@sobrenome, telefone=@telefone, ra=@ra WHERE id=@id";

                IDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                IDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                IDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                IDataParameter paramRa = new SqlParameter("ra", aluno.ra);

                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramSobrenome);
                updateCmd.Parameters.Add(paramTelefone);
                updateCmd.Parameters.Add(paramRa);

                IDataParameter paramId = new SqlParameter("id", aluno.id);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Alunos WHERE id = @id";

                IDataParameter paramId = new SqlParameter("id", id);
                deleteCmd.Parameters.Add(paramId);
                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}