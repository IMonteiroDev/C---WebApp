using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string tel { get; set; }
        public int ra { get; set; }

        public List<Aluno> ListarAlunos(int? id = null)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                return alunoDB.ListarAlunosDB(id);
            }
            catch(Exception ex) {
                throw new Exception($"Erro ao Listar Alunos: Erro => {ex.Message}");

            }
        }

        

        public bool ReescreverArquivo(List<Aluno> listaAlunos)
        {
            var archiveWay = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            
            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(archiveWay, json);

            return true;
        }


        public void Inserir(Aluno aluno)
        {
            //var listarAlunos = this.ListarAlunos();

            //var maxId = listarAlunos.Max(p => p.id); //percorrer ao ver o valor total d alunos
            //aluno.id = maxId + 1;
            //listarAlunos.Add(aluno);

            //ReescreverArquivo(listarAlunos);
            //return aluno;
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.InserirAlunoDB(aluno);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao adicionar Aluno: Erro => {ex.Message}");
            }
        }

        public void Atualizar( Aluno aluno)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar Aluno: Erro => {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var alunoDB = new AlunoDAO();
                alunoDB.deleteAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar Aluno: Erro => {ex.Message}");
            }
        }

    }
}