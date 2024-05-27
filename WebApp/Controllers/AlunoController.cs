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
            return alunos.ListarAlunos(id).FirstOrDefault();
        }

        [HttpPost]
        public IHttpActionResult Post(Aluno aluno)
        {
            try
            {
                Aluno _aluno = new Aluno();

                _aluno.Inserir(aluno);
                return Ok(_aluno.ListarAlunos());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id,[FromBody] Aluno aluno)
        {
            try
            {
                Aluno _aluno = new Aluno();
                aluno.id = id;

                _aluno.Atualizar(aluno);

                return Ok(_aluno.ListarAlunos(id).FirstOrDefault());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            try
            {
                Aluno _aluno = new Aluno();

                _aluno.Deletar(id);

                return Ok("Deletado com Sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
