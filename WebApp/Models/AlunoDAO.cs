using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class AlunoDAO
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;
        public AlunoDAO() {

            //string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
            
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }


        public List<Aluno> ListarAlunosDB(int? id = null)
        {
            var listaAlunos = new List<Aluno>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();
                if (id == null)
                {
                    selectCmd.CommandText = "SELECT * FROM Alunos";
                }
                else
                {
                    selectCmd.CommandText = $"SELECT * FROM Alunos WHERE id = {id}";
                }

                IDataReader result = selectCmd.ExecuteReader();

                while (result.Read())
                {
                    var aluno = new Aluno
                    {
                        id = Convert.ToInt32(result["id"]),
                        name = Convert.ToString(result["name"]),
                        lastName = Convert.ToString(result["lastName"]),
                        tel = Convert.ToString(result["tel"]),
                        ra = Convert.ToInt32(result["ra"])
                    };

                    listaAlunos.Add(aluno);
                }
                conexao.Close();

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


        public void InserirAlunoDB(Aluno aluno)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Alunos (name, lastName, tel, ra) VALUES (@name, @lastName, @tel, @ra)";

                IDbDataParameter paramName = new SqlParameter("name", aluno.name);
                IDbDataParameter paramLastName = new SqlParameter("lastName", aluno.lastName);
                IDbDataParameter paramTel = new SqlParameter("tel", aluno.tel);
                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);

                insertCmd.Parameters.Add(paramName);
                insertCmd.Parameters.Add(paramLastName);
                insertCmd.Parameters.Add(paramTel);
                insertCmd.Parameters.Add(paramRa);

                insertCmd.ExecuteNonQuery();
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

        public void AtualizarAlunoDB(Aluno aluno)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Alunos SET name = @name, lastName = @lastName, tel = @tel, ra = @ra WHERE id = @id";

                IDbDataParameter paramName = new SqlParameter("name", aluno.name);
                IDbDataParameter paramLastName = new SqlParameter("lastName", aluno.lastName);
                IDbDataParameter paramTel = new SqlParameter("tel", aluno.tel);
                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);

                updateCmd.Parameters.Add(paramName);
                updateCmd.Parameters.Add(paramLastName);
                updateCmd.Parameters.Add(paramTel);
                updateCmd.Parameters.Add(paramRa);

                IDbDataParameter paramID = new SqlParameter("id", aluno.id);
                updateCmd.Parameters.Add(paramID);

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

        public void deleteAlunoDB(int id)
        {
            try
            {
                IDbCommand deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Alunos WHERE id=@id";

                IDbDataParameter paramID = new SqlParameter("id", id);
                deleteCmd.Parameters.Add(paramID);

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