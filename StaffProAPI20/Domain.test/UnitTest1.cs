using Microsoft.VisualStudio.TestTools.UnitTesting;
using staffpro.Domain;
using staffpro.entity;
using System;
using System.Linq;

namespace Domain.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Salvar()
        {
            Oportunidade op = new Oportunidade
            {
                Ativo = true,
                //Bairro = "Higienopolis",
                //CEP = "01244-010",
                //Cidade = "S�o Paulo",
                //Complemento = "Perto da band",
                DataCriacao = DateTime.Now,
                DataEdicao = DateTime.Now,
                DataOportunidade = DateTime.Now,
                Descricao = "Evento teste",
                Endereco = new Endereco()
                {
                    Ativo = true,
                    Bairro = "Higienopolis",
                    CEP = "01244-010",
                    Cidade = "S�o Paulo",
                    Complemento = "Perto da Band",
                    DataCriacao = DateTime.UtcNow,
                    DataEdicao = DateTime.UtcNow,
                    Descricao = "Endere�o de teste",
                    Estado = "SP",
                    NumeroLocal = 32,
                },
                //Estado = "SP",
                HoraFim = new TimeSpan(20, 20, 0),
                HoraInicio = new TimeSpan(18, 0, 0),
                Nome = "Evento 1",
                //NumeroLocal = 32,
                Quantidade = 10,
                Status = 1,
                TipoProfissional = 1,
                UsuarioCriacao = 1,
                UsuarioEdicao = 1,
                Valor = 200.00m,
                ID = 0,
                TipoServico = 1
            };

            try
            {
                var t = SimpleJson.SimpleJson.SerializeObject(op);
                OportunidadeBO.SaveAsync(op, 1, "");
            }
            catch (Exception E)
            {
                /////
            }
        }

        [TestMethod]
        public void Editar()
        {
            //OportunidadeBO op = new OportunidadeBO();

            //var a  = op.GetList().Where(x => x.ID == 5).FirstOrDefault();

            //a.Nome = "Evento 2";

           // op.Save(a);

            
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetServicoGroupAsync()
        {
            //ServiceGroupsBO servicesGroup = new ServiceGroupsBO();
            //var retorno = await servicesGroup.GetAllActivate();

            //ServicesBO services = new ServicesBO();

            //var servicesRet = await services.GetAllActivateByGroup(retorno[5].ServiceGroupId);


        }
    }
}
