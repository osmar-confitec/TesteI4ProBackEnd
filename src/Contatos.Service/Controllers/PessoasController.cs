using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contatos.App;
using Contatos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Service.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {

        readonly IPessoaApp _pessoaApp;

        public PessoasController(IPessoaApp pessoaApp)
        {
            _pessoaApp = pessoaApp;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost("IncluirPessoa")]
        public async Task<IActionResult> IncluirPessoa([FromBody] PessoaViewModel pessoaViewModel )
        {
            var pessRet =  await _pessoaApp.IncluirPessoa(pessoaViewModel);
            if (_pessoaApp.Notificacoes.Any())
            {
                string erro = string.Join(Environment.NewLine, _pessoaApp.Notificacoes.Select(x => x.Mensagem));
                return BadRequest(erro);
            }

            return Ok(pessRet);

        }

        [HttpGet("ObterPessoaDetalhada/{id}")]
        public async Task<IActionResult> ObterPessoaDetalhada(string id)
        {
            var pessoaDet =  await _pessoaApp.ObterPessoa(id);
            return Ok(pessoaDet);

        }

        [HttpDelete("DeletarPessoa/{id}")]
        public async Task<IActionResult> DeletarPessoa(string id)
        {
             await _pessoaApp.ExcluirPessoa(id);
            return Ok();
        }

        [HttpDelete("DeletarEmail/{id}")]
        public async Task<IActionResult> DeletarEmail(string id)
        {
            await _pessoaApp.ExcluirMail(id);
            return Ok();
        }

        [HttpDelete("DeletarTeleFone/{id}")]
        public async Task<IActionResult> DeletarTeleFone(string id)
        {
            await _pessoaApp.ExcluirTelefone(id);
            return Ok();
        }

        [HttpPut("AtualizarPessoa")]
        public async Task<IActionResult> AtualizarPessoa([FromBody] PessoaViewModel pessoaViewModel)
        {
            var pessoat =  await _pessoaApp.AtualizarPessoa(pessoaViewModel);
            return Ok(pessoat);
        }


        [HttpGet("ObterPessoas/{nome}")]
        public async Task<IActionResult>Get(string nome = "")

        {
            if (nome == "_")
                nome = string.Empty;
            var pessoas = await _pessoaApp.ObterPessoas(new PessoaConsultaViewModel { Nome = nome });
            return Ok(pessoas);
        }
    }
}