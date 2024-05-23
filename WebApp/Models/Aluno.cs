using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public List<Aluno> ListarAlunos()
        {
            var archiveWay = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(archiveWay);
            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

            return listaAlunos;
        }

        public bool ReescreverArquivo(List<Aluno> listaAlunos)
        {
            var archiveWay = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            
            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(archiveWay, json);

            return true;
        }


        public Aluno Inserir(Aluno aluno)
        {
            var listarAlunos = this.ListarAlunos();

            var maxId = listarAlunos.Max(p => p.id); //percorrer ao ver o valor total d alunos
            aluno.id = maxId + 1;
            listarAlunos.Add(aluno);

            ReescreverArquivo(listarAlunos);
            return aluno;
        }

        public Aluno Atualizar(int id, Aluno aluno)
        {
            var listarAlunos = this.ListarAlunos();
            
            var itemIndex = listarAlunos.FindIndex(p => p.id == id);
            if (itemIndex >= 0)
            {
                aluno.id = id;
                listarAlunos[itemIndex] = aluno;
            }
            else
            {
                return null;
            }

            ReescreverArquivo(listarAlunos);
            return aluno;
        }

        public bool Deletar(int id)
        {
            var listarAlunos = this.ListarAlunos();
            
            var itemIndex = listarAlunos.FindIndex(p=>p.id == id);
            if (itemIndex >= 0)
            {
                listarAlunos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listarAlunos);
            return true;
        }

    }
}