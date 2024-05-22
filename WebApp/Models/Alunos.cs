using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Alunos
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string tel { get; set; }
        public int ra { get; set; }
        public List<Alunos> listaAlunos()
        {
            var archiveWay = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(archiveWay);
            var listaAlunos = JsonConvert.DeserializeObject<List<Alunos>>(json);

            return listaAlunos;
        }
    }
}