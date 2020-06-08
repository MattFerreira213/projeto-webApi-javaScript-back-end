using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;
using static WebApp.BaseUsuarios;

namespace WebApp.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Listar")]
        [Authorize(Roles = Funcao.Professor)]
        public IHttpActionResult Listar()
        {
            try
            {
                AlunoModel aluno = new AlunoModel();
                var alunos = aluno.ListarAluno();
                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Listar/{id:int}/{nome?}")]
        public IHttpActionResult ListarPorId(int id, string nome = null)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();

                return Ok(aluno.ListarAluno().FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Aluno
        [HttpPost]
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Inserir(aluno);

                return Ok(_aluno.ListarAluno());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Aluno/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();
                aluno.id = id;

                _aluno.Atualizar(aluno);

                return Ok(_aluno.ListarAluno().FirstOrDefault(al => al.id == id));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Aluno/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Deletar(id);

                return Ok("Deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
