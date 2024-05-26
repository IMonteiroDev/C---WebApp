using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*","*","*")] //Decoration
    [RoutePrefix("api/Aluno")]

    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Recuperar")]
        public IHttpActionResult Get()
        {
            try
            {
                Aluno aluno = new Aluno();
                return Ok(aluno.ListarAlunos());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Recuperar/{id}")]
        public Aluno Get(int id)
        {  
            Aluno alunos = new Aluno();
            return alunos.ListarAlunos().Where(x=> x.id == id).FirstOrDefault();
        }

        // POST: api/Aluno
        public List<Aluno> Post(Aluno aluno)
        {
            Aluno _aluno = new Aluno();

            _aluno.Inserir(aluno);
            return _aluno.ListarAlunos();
        }

        // PUT: api/Aluno/5
        public Aluno Put(int id,[FromBody] Aluno aluno)
        {
            Aluno _aluno = new Aluno();

            return _aluno.Atualizar(id, aluno);
        }

        // DELETE: api/Aluno/5
        public void Delete(int id)
        {
            Aluno _aluno = new Aluno();

            _aluno.Deletar(id);
        }
    }
}
